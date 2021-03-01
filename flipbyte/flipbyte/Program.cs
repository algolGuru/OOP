using System;
using System.Linq;

namespace flipbyte
{
    class Program
    {
        static void Main( string[] args )
        {
            if( args.Count() != 1 )
            {
                Console.WriteLine( "Invalid count of params" );
                return;
            }

            int inputByte;
            try
            {
                inputByte = int.Parse( args[ 0 ] );
            }
            catch
            {
                Console.WriteLine( "Invalid input data" );
                return;
            }

            int result;

            if( ( inputByte >= 0 ) && ( inputByte <= 255 ) )
                result = ReverseBits( inputByte );
            else
            {
                Console.WriteLine( "Input data more than 1 byte" );
                return;
            }

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
