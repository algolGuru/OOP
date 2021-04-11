using System;
using System.Collections.Generic;
using System.Text;

namespace VolumetricBodies.Bodies
{
    public class CompoundBody : Body
    {
        private List<Body> _bodies = new List<Body>();

        public CompoundBody( List<Body> bodies )
        {
            foreach( var body in bodies )
            {
                if( body.GetVolume() > 0 && body.GetMass() > 0 && body.GetDensity() > 0 )
                {
                    _bodies.Add( body );
                }
            }
            CountBodyParams( bodies );
        }

        public bool AddChildBpdy( Body child )
        {
            _bodies.Add( child );

            return true;
        }

        public List<Body> GetBodies()
        {
            return _bodies;
        }

        public override string ToString()
        {
            string bodyString = 
                "Параметры составного тела: \n" +
                $"Средняя плотность: {Density} \n" +
                $"Полная масса: {Mass} \n" +
                $"Полный объем: {Volume} \n" +
                $"Входящие тела: \n";

            foreach( var body in _bodies )
            {
                bodyString += body.ToString() + "\n";
            }

            return bodyString;
        }

        private void CountBodyParams( List<Body> bodies )
        {
            Mass = 0;
            Volume = 0;

            foreach( var body in bodies )
            {
                Mass += body.GetMass();
                Volume += body.GetVolume();
            }

            Density = Mass / Volume;
        }
    }
}
