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
            _bodies.AddRange( bodies );
            CountBodyParams( bodies );
        }

        public bool AddChildBpdy( Body child )
        {
            _bodies.Add( child );

            return true;
        }

        public override string ToString()
        {
            string bodyString = "";

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
