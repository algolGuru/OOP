using System;
using System.IO;
using System.Linq;

namespace delete
{
    class Program
    {
        static void Main( string[] args )
        {
            var input = File.ReadAllLines( "../../../input.txt" );

            var numberOfElements = input[ 0 ].Split( ' ' ).Select(item => int.Parse( item )).ToList()[ 1 ];
            var deleter = input[ 0 ].Split( ' ' ).Select( item => int.Parse( item ) ).ToList()[ 0 ];
            var counter = 1;




            while ( Proizv( counter, numberOfElements ) <= deleter )
            {
                counter++;
                Console.WriteLine( '1' );
            }
        }
         
        static int Proizv( int start, int numberOfElements )
        {
            var result = start; 
            for( int i = 1; i < numberOfElements; i++ )
            {
                result = result * (start + i);
            }

            return result;
        }

    }
}
