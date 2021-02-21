using System;
using System.Linq;

namespace flipbyte
{
    class Program
    {
        static void Main( string[] args )
        {
            if( args.Count() != 1 )
                throw new Exception( "Invalid count of params" );
            
            int inputByte;
            try
            {
                inputByte = int.Parse( args[ 0 ] );
            }
            catch
            {
                throw new Exception( "Input data is not correct" );
            }

            int result;
            if( ( inputByte >= 0 ) && ( inputByte <= 255 ) )
                result = ReverseBits( inputByte );
            else
                throw new Exception( "Input data more then 1 byte" );

            Console.WriteLine( result );
        }

        public static int ReverseBits( int inputByte )
        {
            var result = 0;
            for( int i = 0; i < 8; i++ )
            {
                result <<= 1;
                result += inputByte % 2;
                inputByte >>= 1;
            }

            return result;
        }
    }
}
