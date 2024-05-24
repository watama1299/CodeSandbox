public class Plate384 : Plate
{
    public override int ColCount { get; } = 24;
    public override int RowCount { get; } = 16;
    public override double ColPitch { get; } = 4.5;
    public override double AspiratorOffsetY { get; set; } = 0.3;
    public override double DispenserOffsetY { get; set; } = 0;
    
    public Plate384( double aspiratorOffsetY = 0, double dispenserOffsetY = 0 )
    {
        AspiratorOffsetY = aspiratorOffsetY;
        DispenserOffsetY = dispenserOffsetY;
    }

    public Plate384()
    {
        
    }
}
