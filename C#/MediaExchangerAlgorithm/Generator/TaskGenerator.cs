public static class TaskGenerator
{
    public static IEnumerable<MachineAction> GetAspirateActions( int colNum, int rowCount )
    {
        foreach ( var coordinate in GetRowCoordinates( colNum, rowCount ))
        {
            yield return new MachineAction( Action.Aspirate, coordinate );
        }
    }

    public static IEnumerable<MachineAction> GetDispenseActions( int colNum, int rowCount )
    {
        foreach ( var coordinate in GetRowCoordinates( colNum, rowCount ))
        {
            yield return new MachineAction( Action.Dispense, coordinate );
        }
    }

    public static IEnumerable<Coordinate> GetRowCoordinates( int colNum, int rowCount )
    {
        for( int i = 1; i <= rowCount; i++ )
        {
            yield return new Coordinate( colNum, i );
        }
    }
}
