namespace VolumetricBodies.Bodies
{
    public class Parallelepiped : Body
    {
        public Parallelepiped(
            double width,
            double height,
            double depth,
            double density )
        {
            if( width == 0 || height == 0 || depth == 0 || density == 0 )
            {
                width = -1;
                height = -1;
                depth = -1;
                density = -1;
            }
            _width = width;
            _height = height;
            _depth = depth;
            Density = density;
            Volume = CountVolume( width, height, depth );
            Mass = Density * Volume;
        }

        private double _width;
        private double _height;
        private double _depth;

        public double GetWidth()
        {
            return _width;
        }

        public double GetHeight()
        {
            return _height;
        }

        public double GetDept()
        {
            return _depth;
        }

        public override string ToString()
        {
            return
                $"Тип объекта: Параллелепипед \n" +
                $"Масса тела: {Mass} \n" +
                $"Объем тела: {Volume} \n" +
                $"Плотность тела: {Density}";
        }

        private double CountVolume( double width, double height, double dept )
        {
            return width * height * dept;
        }
    }
}