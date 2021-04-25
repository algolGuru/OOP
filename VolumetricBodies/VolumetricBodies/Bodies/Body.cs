namespace VolumetricBodies.Bodies
{
    public struct BodyParams 
    {
        public double Density { get; set; }
        public double Mass { get; set; }
        public double Volume { get; set; }
    }

    public abstract class Body
    {
        public abstract BodyParams GetState();
    }
}
