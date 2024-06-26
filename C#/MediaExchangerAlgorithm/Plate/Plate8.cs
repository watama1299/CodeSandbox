public class Plate8 : Plate
{
    public override int ColCount { get; } = 4;
    public override int RowCount { get; } = 2;
    public override double ColPitch { get; } = 30.7;
    public override double AspiratorOffsetY { get; set; } = 1.5;
    public override double DispenserOffsetY { get; set; } = 1.575;
    
    public Plate8( double aspiratorOffsetY = 0, double dispenserOffsetY = 0 )
    {
        AspiratorOffsetY = aspiratorOffsetY;
        DispenserOffsetY = dispenserOffsetY;
    }

    public Plate8()
    {
        
    }
}
