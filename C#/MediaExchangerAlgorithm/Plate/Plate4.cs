public class Plate4 : Plate
{
    public override int ColCount { get; } = 4;
    public override int RowCount { get; } = 1;
    public override double ColPitch { get; } = 30.7;
    public override double AspiratorOffsetY { get; set; } = 1.5;
    public override double DispenserOffsetY { get; set; } = 1.325;

    public Plate4( double aspiratorOffsetY = 0, double dispenserOffsetY = 0 )
    {
        AspiratorOffsetY = aspiratorOffsetY;
        DispenserOffsetY = dispenserOffsetY;
    }

    public Plate4()
    {
        
    }
}
