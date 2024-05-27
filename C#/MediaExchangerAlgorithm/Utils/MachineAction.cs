public struct MachineAction
{
    public ProcessingType ProcessingType { get; }
    public ActionType ActionType { get; }
    public Coordinate Coordinate { get; }

    public MachineAction( ProcessingType processingType, ActionType actionType, Coordinate coordinate )
    {
        ProcessingType = processingType;
        ActionType = actionType;
        Coordinate = coordinate;
    }

    // override object.Equals
    public override bool Equals(object? obj) => obj is MachineAction other && this.Equals(other);

    public readonly bool Equals(MachineAction ma) => ActionType.Equals( ma.ActionType ) && Coordinate.Equals( ma.Coordinate );
    
    // override object.GetHashCode
    public override int GetHashCode()
    {
        return HashCode.Combine( ActionType, Coordinate );
    }
}

// Action exists
public enum ActionType
{
    Aspirate,
    Dispense,
}

public enum ProcessingType
{
    NonParallel,
    Parallel
}