public static class ProcessGenerator
{
    public static IEnumerable<IEnumerable<MachineAction>> SimultaneousProcess( int nTimes , int nPrePost, int rowCount )
    {
        Console.WriteLine( "\nSimultaneous media exchange BEGIN..." );
        for ( int i = nTimes; i > 0; i-- )
        {
            var disp = TaskGenerator.GetDispenseActions( i + nPrePost, rowCount );
            var asp = TaskGenerator.GetAspirateActions( i, rowCount );
            yield return asp.Concat( disp );
        }
        Console.WriteLine( "Simultaneous media exchange END...\n" );
    }

    public static IEnumerable<IEnumerable<MachineAction>> NonSimultaneousProcess( int nTimes , int nPrePost, int rowCount )
    {
        Console.WriteLine( "\nNon-simultaneous media exchange BEGIN...\n" );
        for ( int i = nTimes; i > 0; i-- )
        {
            yield return TaskGenerator.GetDispenseActions( i + nPrePost, rowCount );
            Console.WriteLine( "THEN" );
            yield return TaskGenerator.GetAspirateActions( i, rowCount );
        }
        Console.WriteLine( "Non-simultaneous media exchange END...\n" );
    }
}