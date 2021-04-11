using System;

namespace VolumetricBodies.Bodies
{
    public class Sphere : Body
    {
        public Sphere( double radius, double density )
        {
            _radius = radius;
            Density = density;
            Volume = CountVolume( _radius );
            Mass = Density * Volume;
        }

        private readonly double _radius;

        public double GetRadius()
        {
            return _radius;
        }

        public override string ToString()
        {
            return
                $"Тип объекта: Сфера \n" +
                $"Масса тела: {Mass} \n" +
                $"Объем тела: {Volume} \n" +
                $"Плотность тела: {Density}";
        }

        private double CountVolume( double radius )
        {
            return ( 4 * Math.PI * Math.Pow( radius, 3 ) ) / 3;
        }
    }
}
