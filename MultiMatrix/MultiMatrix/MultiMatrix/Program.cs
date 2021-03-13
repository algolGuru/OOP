using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MultiMatrix
{
    class Program
    {
        const string backslash = @"\";
        static void Main( string[] args )
        {
            if( args.Count() != 2 )
            {
                Console.WriteLine( "Invalid count of parameters" );
                return;
            }
            var wasError = false;

            var firstMatrix = new List<List<float>>();
            wasError = FillMatrix( Directory.GetCurrentDirectory() + backslash + args[ 0 ], ref firstMatrix );

            var secondMatrix = new List<List<float>>();
            wasError = FillMatrix( Directory.GetCurrentDirectory() + backslash + args[ 1 ], ref secondMatrix );

            if( wasError )
            {
                Console.WriteLine( "Invalid data in input" );
            }
            else
            {
                var matrix = MulitiMatrix( firstMatrix, secondMatrix );
                WriteMatrixInOutput( matrix );
            }
        }

        public static bool FillMatrix( string filePath, ref List<List<float>> matrix )
        {
            string[] matrixText = new string[] { };

            if( File.Exists( filePath ) )
            {
                matrixText = File.ReadAllLines( filePath );
            }
            else
            {
                return true;
            }

            matrix = new List<List<float>>();

            foreach( var line in matrixText )
            {
                var floatNumbersLine = new List<float>();
                try
                {
                    floatNumbersLine = line
                        .Split( ' ' )
                        .Select( item => float.Parse( item ) ).ToList();
                }
                catch
                {
                    return true;
                }

                matrix.Add( floatNumbersLine );
            }

            return false;
        }

        public static List<List<float>> MulitiMatrix( List<List<float>> firstMatrix, List<List<float>> secondMatrix )
        {
            var resultMatrix = FillZeroMatrix();

            for( int i = 0; i < 3; i++ )
            {
                for( int j = 0; j < 3; j++ )
                {
                    resultMatrix[ i ][ j ] = 0;
                    for( int k = 0; k < 3; k++ )
                    {
                        resultMatrix[ i ][ j ] = resultMatrix[ i ][ j ] + firstMatrix[ i ][ k ] * secondMatrix[ k ][ j ];
                    }
                }
            }

            return resultMatrix;
        }

        public static List<List<float>> FillZeroMatrix()
        {
            var resultMatrix = new List<List<float>>();
            for( int i = 0; i < 3; i++ )
            {
                var lineOfMatrix = new List<float>();
                for( int j = 0; j < 3; j++ )
                {
                    lineOfMatrix.Add( 0 );
                }

                resultMatrix.Add( lineOfMatrix );
            }

            return resultMatrix;
        }

        public static void WriteMatrixInOutput( List<List<float>> matrix )
        {
            foreach( var line in matrix )
            {
                foreach( var item in line )
                {
                    Console.Write( item.ToString("F3") + "\t" );
                }

                Console.WriteLine();
            }
        }
    }
}
