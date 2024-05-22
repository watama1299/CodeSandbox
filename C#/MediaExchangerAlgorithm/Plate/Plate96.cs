public class Plate96 : Plate
{
    public override int ColCount { get; } = 12;
    public override int RowCount { get; } = 8;
    public override double ColPitch { get; } = 9;
    public override double TiltAngle { get; set; } = 0;
    public override double AspiratorOffsetY { get; set; } = 0;
    public override double DispenserOffsetY { get; set; } = 0;
    
    public Plate96( double tiltAngle = 0, double aspiratorOffsetY = 0, double dispenserOffsetY = 0 )
    {
        TiltAngle = tiltAngle;
        AspiratorOffsetY = aspiratorOffsetY;
        DispenserOffsetY = dispenserOffsetY;
    }

    public Plate96()
    {
        
    }
}
