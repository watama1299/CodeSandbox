public struct Coordinate
{
    public int Column { get; }
    public int Row { get; }

    public Coordinate( int column, int row )
    {
        Column = column;
        Row = row;
    }

    // override object.Equals
    public override bool Equals(object? obj) => obj is Coordinate other && this.Equals(other);

    public readonly bool Equals(Coordinate c) => Column == c.Column && Row == c.Row;
    
    // override object.GetHashCode
    public override int GetHashCode()
    {
        return HashCode.Combine( Column, Row );
    }
}
