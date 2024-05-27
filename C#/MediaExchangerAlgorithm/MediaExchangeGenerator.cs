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
        int nPrePost;

        // Calculate how much is actual nozzle offset
        // Calculation done if aspirator at target location
        // Dispenser nozzle location when aspirator nozzle is set on a target
        int nPreAspOrigin = ( int ) Math.Ceiling( lengthBetweenNozzle / columnPitch );
        double dspNozzleLocation = Math.Round( aspiratorOffsetY + nPreAspOrigin*columnPitch - lengthBetweenNozzle, 4 );
        double dspOffsetDifference = Math.Round( dspNozzleLocation - dispenserOffsetY, 4 );

        // Calculation done if dispenser at target location
        int nPreDspOrigin = ( int ) Math.Floor( lengthBetweenNozzle / columnPitch );
        double aspNozzleLocation = Math.Round( dispenserOffsetY + lengthBetweenNozzle, 4 );
        double aspOffsetDifference = Math.Round( aspNozzleLocation - ( aspiratorOffsetY + nPreDspOrigin*columnPitch ), 4 );



        bool simulProc;
        bool aspirateFirst;
        if ( dspOffsetDifference < aspOffsetDifference )
        {
            aspirateFirst = false;
            nPrePost = nPreAspOrigin;
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
        }
        else
        {
            aspirateFirst = true;
            nPrePost = nPreDspOrigin;
            if ( aspOffsetDifference > 0 )
            {
                simulProc = aspOffsetDifference <= tolerance
                            && aspOffsetDifference >= 0;
            }
            else
            {
                simulProc = aspNozzleLocation >= 0
                            && aspOffsetDifference >= -tolerance
                            && aspOffsetDifference <= 0;
            }
        }

        // How many times the aspirate-dispense need to be repeated
        int nTimes = columnCount - nPrePost;


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
                if ( aspirateFirst )
                {
                    yield return new MachineAction( ProcessingType.NonSimultaneous, ActionType.Aspirate, i );
                    yield return new MachineAction( ProcessingType.NonSimultaneous, ActionType.Dispense, i + nPrePost );
                }
                else
                {
                    yield return new MachineAction( ProcessingType.NonSimultaneous, ActionType.Dispense, i + nPrePost );
                    yield return new MachineAction( ProcessingType.NonSimultaneous, ActionType.Aspirate, i );
                }
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