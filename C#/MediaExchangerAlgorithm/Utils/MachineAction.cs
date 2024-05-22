public struct MachineAction
{
    public Action Action { get; }
    public Coordinate Coordinate { get; }

    public MachineAction(Action action, Coordinate coordinate)
    {
        Action = action;
        Coordinate = coordinate;
    }

    // override object.Equals
    public override bool Equals(object? obj) => obj is MachineAction other && this.Equals(other);

    public readonly bool Equals(MachineAction ma) => Action.Equals( ma.Action ) && Coordinate.Equals( ma.Coordinate );
    
    // override object.GetHashCode
    public override int GetHashCode()
    {
        return HashCode.Combine( Action, Coordinate );
    }
}

public enum Action
{
    Aspirate,
    Dispense
}