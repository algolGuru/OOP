namespace VolumetricBodies.Bodies
{
    public abstract class Body
    {
        protected double Density;
        protected double Volume;
        protected double Mass;

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
