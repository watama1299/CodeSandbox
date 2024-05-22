public abstract class Plate
{
    public virtual int ColCount { get; }
    public virtual int RowCount { get; }
    public virtual double ColPitch { get; }
    public virtual double TiltAngle { get; set;}
    public virtual double AspiratorOffsetY { get; set; }
    public virtual double DispenserOffsetY { get; set; }
}
