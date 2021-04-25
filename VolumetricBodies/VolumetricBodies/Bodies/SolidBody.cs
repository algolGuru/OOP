namespace VolumetricBodies.Bodies
{
    public abstract class SolidBody : Body
    {
        protected double Density;
        protected double Volume;
        protected double Mass;

        public override BodyParams GetState()
        {
            return new BodyParams()
            {
                Density = Density,
                Mass = Mass,
                Volume = Volume
            };
        }

        public double GetDensity()
        {
            return Density;
        }

        //get Volume
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
