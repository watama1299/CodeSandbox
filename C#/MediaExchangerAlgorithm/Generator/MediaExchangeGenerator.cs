public static class MediaExchangeGenerator
{
    public static IEnumerable<MachineAction> GenerateRoutine(
        double lengthBetweenNozzle,
        double aspiratorOffsetY,
        double dispenserOffsetY,
        double columnPitch,
        int columnCount,
        double tolerance = 0.0,
        double plateTiltAngle = 0.0
    )
    {   
        // Tilt angle correction
        aspiratorOffsetY *= Math.Cos( Math.PI * plateTiltAngle / 180 );
        dispenserOffsetY *= Math.Cos( Math.PI * plateTiltAngle / 180 );
        columnPitch *= Math.Cos( Math.PI * plateTiltAngle / 180 );

        // Count how many times to early-aspirate and late-dispense
        int nPrePost = ( int ) Math.Ceiling( lengthBetweenNozzle / columnPitch );

        // How many times the aspirate-dispense need to be repeated
        int nTimes = columnCount - nPrePost;

        // Calculate how much is actual nozzle offset
        double dspNozzleLocation = Math.Round( aspiratorOffsetY + nPrePost*columnPitch - lengthBetweenNozzle, 4 );
        double dspOffsetDifference = Math.Round( dspNozzleLocation - dispenserOffsetY, 4 );

        bool simulProc;
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


        // Pre-aspirate
        // Aspirate early wells when plate is positioned only underneath aspirate nozzle
        for ( int i = columnCount; i > nTimes; i-- )
        {
            yield return new MachineAction( ProcessingType.NonSimultaneous, ActionType.Aspirate, i );
        }

        // Once plate is underneath both nozzles, choose whether simulataneous process or not
        if ( simulProc )
        {
            for ( int i = nTimes; i > 0; i-- )
            {
                yield return new MachineAction( ProcessingType.Simultaneous, ActionType.Dispense, i + nPrePost );
                yield return new MachineAction( ProcessingType.Simultaneous, ActionType.Aspirate, i );
            }
        }
        else
        {
            for ( int i = nTimes; i > 0; i-- )
            {
                yield return new MachineAction( ProcessingType.NonSimultaneous, ActionType.Dispense, i + nPrePost );
                yield return new MachineAction( ProcessingType.NonSimultaneous, ActionType.Aspirate, i );
            }
        }

        // Post-dispense
        // Dispense into remaining wells after plate is only underneath dispense nozzle
        for ( int i = columnCount - nTimes; i > 0; i-- )
        {
            yield return new MachineAction( ProcessingType.NonSimultaneous, ActionType.Dispense, i );
        }
    }
}