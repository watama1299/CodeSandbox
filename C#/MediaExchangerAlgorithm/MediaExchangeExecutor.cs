public class MediaExchangeExecutor
{
    public static async Task ExecuteRoutine(
        Plate plateUsed,
        Dispenser chosenDispenser,
        double tolerance = 0.0,
        double plateTiltAngle = 0.0
    )
    {
        var machineActions = MediaExchangeGenerator.GenerateRoutine(
            ( int ) chosenDispenser,
            plateUsed.AspiratorOffsetY,
            plateUsed.DispenserOffsetY,
            plateUsed.ColPitch,
            plateUsed.ColCount,
            tolerance,
            plateTiltAngle
        );

        foreach( var machineAction in machineActions )
        {
            await RunMachineAction( machineAction );
        }
    }

    private static void VerboseAction( MachineAction ma )
    {
        Console.WriteLine( $"{ ma.ProcessingType } { ma.ActionType } DONE --> Column: [{ ma.ColumnNumber }]" );
    }

    private static async Task RunMachineAction( MachineAction action )
    {
        await Task.Delay( new Random().Next( 0, 500 ) );
        VerboseAction( action );
    }
}
