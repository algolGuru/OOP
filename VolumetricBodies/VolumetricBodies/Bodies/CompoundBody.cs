using System.Collections.Generic;

namespace VolumetricBodies.Bodies
{
    public class CompoundBody : Body
    {
        private List<Body> _bodies = new List<Body>();
        public CompoundBody Parent { get; }

        public CompoundBody()
        {
            Parent = null;
        }

        public CompoundBody( CompoundBody parent )
        {
            Parent = parent;
        }

        public bool AddChildBody( Body child )
        {
            if( !ReferenceEquals( this, child ) )
            {
                //is
                if( ReferenceEquals( GetType(), child.GetType() ) )
                {
                    while( true )
                    {
                        var link = Parent;
                        if( link == child )
                        {
                            return false;
                        }
                        if( link == null )
                        {
                            break;
                        }
                    }
                }

                var bodyParms = child.GetState();
                if( bodyParms.Density > 0 && bodyParms.Mass > 0 && bodyParms.Volume > 0 )
                {
                    _bodies.Add( child );
                    return true;
                }
            }

            return false;
        }

        public List<Body> GetBodies()
        {
            return _bodies;
        }

        public override string ToString()
        {
            var bodyParams = GetState();

            string bodyString =
                "Тип объекта: Составное тело \n" +
                "   Параметры составного тела: \n" +
                $"      Средняя плотность: {bodyParams.Density} \n" +
                $"      Полная масса: {bodyParams.Mass} \n" +
                $"      Полный объем: {bodyParams.Volume} \n" +
                $"Входящие тела: \n";

            foreach( var body in _bodies )
            {
                bodyString += body.ToString() + "\n";
            }

            return bodyString;
        }

        public override BodyParams GetState()
        {
            var bodyParams = new BodyParams
            {
                Density = 0,
                Mass = 0,
                Volume = 0
            };

            foreach( var body in _bodies )
            {
                bodyParams.Volume += body.GetState().Volume;
                bodyParams.Mass += body.GetState().Mass;
            }

            bodyParams.Density = bodyParams.Mass / bodyParams.Volume;

            return bodyParams;
        }
    }
}
