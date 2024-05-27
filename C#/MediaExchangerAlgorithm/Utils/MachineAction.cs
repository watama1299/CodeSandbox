public struct MachineAction
{
    public ProcessingType ProcessingType { get; }
    public ActionType ActionType { get; }
    public int ColumnNumber { get; }

    public MachineAction( ProcessingType processingType, ActionType actionType, int columnNumber )
    {
        ProcessingType = processingType;
        ActionType = actionType;
        ColumnNumber = columnNumber;
    }

    // override object.Equals
    public override bool Equals( object? obj ) => obj is MachineAction other && this.Equals(other);

    public readonly bool Equals( MachineAction ma ) => 
        ProcessingType.Equals ( ma.ProcessingType )
        && ActionType.Equals( ma.ActionType )
        && ColumnNumber.Equals( ma.ColumnNumber );
    
    // override object.GetHashCode
    public override int GetHashCode()
    {
        return HashCode.Combine( ProcessingType, ActionType, ColumnNumber );
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
    NonSimultaneous,
    Simultaneous
}