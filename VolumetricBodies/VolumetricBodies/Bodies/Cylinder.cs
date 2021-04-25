using System;

namespace VolumetricBodies.Bodies
{
    public class Cylinder : SolidBody
    {
        public Cylinder( double baseRadius, double height, double density )
        {
            if( baseRadius == 0 || height == 0 || density == 0 )
            {
                baseRadius = -1;
                height = -1;
                density = -1;
            }
            _baseRadius = baseRadius;
            _height = height;
            Density = density;
            Volume = CountVolume( baseRadius, height );
            Mass = Density * Volume;
        }

        private readonly double _baseRadius;
        private readonly double _height;

        public double GetBaseRadius()
        {
            return _baseRadius;
        }

        public double GetHeight()
        {
            return _height;
        }

        public override string ToString()
        {
            return
                $"Тип объекта: Цилиндр \n" +
                $"  Масса тела: {Mass} \n" +
                $"  Объем тела: {Volume} \n" +
                $"  Плотность тела: {Density}";
        }

        private double CountVolume( double baseRadius, double height )
        {
            return Math.PI * Math.Pow( baseRadius, 2 ) * height;
        }
    }
}
