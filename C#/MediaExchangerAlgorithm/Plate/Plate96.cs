public class Plate96 : Plate
{
    public override int ColCount { get; } = 12;
    public override int RowCount { get; } = 8;
    public override double ColPitch { get; } = 5.5;
    public override double AspiratorOffsetY { get; set; } = 0;
    public override double DispenserOffsetY { get; set; } = 0;
    
    public Plate96( double aspiratorOffsetY = 0, double dispenserOffsetY = 0 )
    {
        AspiratorOffsetY = aspiratorOffsetY;
        DispenserOffsetY = dispenserOffsetY;
    }

    public Plate96()
    {
        
    }
}
