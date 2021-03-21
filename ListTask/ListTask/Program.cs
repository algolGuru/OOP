using System;
using System.Collections.Generic;
using System.Linq;

namespace ListTask
{
    public class ListElementsMultiplyer
    {
        public List<float> MultiplyElementsByTheMin( List<float> list )
        {
            if( list.Count != 0 )
            {
                var minElement = list.Min();
                for( int i = 0; i < list.Count; i++ )
                {
                    list[ i ] = list[ i ] * minElement;
                }
            }

            return list;
        }
    }

    public class Program
    {
        static void Main( string[] args )
        {
            var input = Console.ReadLine();
            var list = new List<float>();
            var isValidInput = ReadListFroamInput( input, list );
            if ( isValidInput )
            {
                ListElementsMultiplyer matrixElementsMultiplyer = new ListElementsMultiplyer();
                matrixElementsMultiplyer.MultiplyElementsByTheMin( list );
            }

            PrintSortedResult( list, isValidInput );
        }

        public static bool ReadListFroamInput( string input, List<float> floatList )
        {
            var list =  input.Split( ' ' ).ToList();
            for( int i = 0; i < list.Count; i++ )
            {
                try
                {
                    floatList.Add( float.Parse( list[ i ] ) );
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        public static void PrintSortedResult( List<float> list, bool isValidInput )
        {
            if ( isValidInput )
            {
                list.Sort();

                foreach( var item in list )
                {
                    Console.Write( item.ToString( "F3" ) + " " );
                }
            }
            else
            {
                Console.WriteLine( "Error: Input is empty or invalid" );
            }

        }
    }
}
