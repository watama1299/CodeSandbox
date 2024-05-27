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
            plateUsed.RowCount,
            tolerance,
            plateTiltAngle

        );

        foreach( var machineAction in machineActions )
        {
            await RunMachineAction( machineAction );
        }
    }

    private static void VerboseAction( MachineAction machineAction )
    {
        var processingType = machineAction.ProcessingType;
        var actionType = machineAction.ActionType;
        var coordinate = machineAction.Coordinate;

        Console.WriteLine( $"{ processingType } { actionType } DONE --> Column: [{ coordinate.Column }]" );
    }

    private static async Task RunMachineAction( MachineAction action )
    {
        await Task.Delay( new Random().Next( 0, 500 ) );
        VerboseAction( action );
    }
}
