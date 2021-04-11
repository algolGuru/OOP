namespace VolumetricBodies.Bodies
{
    public abstract class Body
    {
        public double Density;
        public double Volume;
        public double Mass;

        public double GetDensity()
        {
            return Density;
        }

        public double GetVolume()
        {
            return Volume;
        }

        public double GetMass()
        {
            return Mass;
        }
    }
}
