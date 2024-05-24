public class MediaExchangerExecutor
{
    private readonly Plate _plateUsed;

    public MediaExchangerExecutor( Plate plateUsed )
    {
        _plateUsed = plateUsed;
    }

    // tolerance refers to how far off the target can one nozzle be
    public Task ExecuteTask( int lengthBetweenNozzle, double tolerance = 0.0, double plateTiltAngle = 0.0 )
    {
        var aspOffsetY = _plateUsed.AspiratorOffsetY;
        var dspOffsetY = _plateUsed.DispenserOffsetY;
        var colPitch = _plateUsed.ColPitch;
        var colCount = _plateUsed.ColCount;
        var rowCount = _plateUsed.RowCount;

        // Tilt angle correction
        aspOffsetY *= Math.Cos( Math.PI * plateTiltAngle / 180 );
        dspOffsetY *= Math.Cos( Math.PI * plateTiltAngle / 180 );
        colPitch *= Math.Cos( Math.PI * plateTiltAngle / 180 );

        // Count how many times to early-aspirate and late-dispense
        int nPrePost = ( int ) Math.Ceiling( lengthBetweenNozzle / colPitch );

        // Calculate how much is actual nozzle offset
        double dspNozzleLocation = Math.Round( aspOffsetY + nPrePost*colPitch - lengthBetweenNozzle, 2 );
        double dspOffsetDifference = Math.Round( dspNozzleLocation - dspOffsetY, 2 );

        bool simulProc = false;
        if ( dspOffsetDifference > 0 )
        {
            simulProc = dspOffsetDifference <= tolerance
                        && dspOffsetDifference >= 0;
        }
        else
        {
            simulProc = dspNozzleLocation >= 0
                        && dspOffsetDifference >= -tolerance
                        && dspOffsetDifference <= 0;
        }

        // How many times the aspirate-dispense need to be repeated
        int nTimes = colCount - nPrePost;

        return Task.Run( async () =>
        {
            // Pre-aspirate
            // Aspirate early wells when plate is positioned only underneath aspirate nozzle
            for ( int i = colCount; i > nTimes; i-- )
            {
                await RunMachineAction( TaskGenerator.GetAspirateActions( i, rowCount ) );
                Console.WriteLine();
            }

            // Once plate is underneath both nozzles, choose whether simulataneous process or not
            if ( simulProc )
            {
                foreach( var actions in ProcessGenerator.SimultaneousProcess( nTimes, nPrePost, rowCount ) )
                {
                    await RunMachineAction( actions );
                    Console.WriteLine();
                }
            }
            else
            {
                foreach( var actions in ProcessGenerator.NonSimultaneousProcess( nTimes, nPrePost, rowCount ) )
                {
                    await RunMachineAction( actions );
                    Console.WriteLine();
                }
            }

            // Post-dispense
            // Dispense into remaining wells after plate is only underneath dispense nozzle
            for ( int i = colCount - nTimes; i > 0; i-- )
            {
                await RunMachineAction( TaskGenerator.GetDispenseActions( i, rowCount ) );
                Console.WriteLine();
            }
        });
    }

    private void VerboseAction( MachineAction machineAction )
    {
        var action = machineAction.Action;
        var coordinate = machineAction.Coordinate;

        Console.WriteLine( $"{ action } DONE --> [{( char )( 64 + coordinate.Row )} { coordinate.Column }]" );
    }

    private Task RunMachineAction( IEnumerable<MachineAction> machineActions )
    {
        return Task.Run( () =>
        {
            List<Task> tasks = new();
            foreach ( var action in machineActions )
            {
                tasks.Add( Task.Run( async () =>
                {
                    await Task.Delay( new Random().Next( 0, 500 ) );
                    VerboseAction( action );
                } ) );
            }
            Task.WaitAll( tasks.ToArray() );
        });
    }
}
