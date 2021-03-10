using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Fill
{
    public static class Program
    {
        public const int MaxMatrixSize = 99;
        public struct Point
        {
            public Point( int y, int x )
            {
                Y = y;
                X = x;
            }

            public int Y;
            public int X;
        }

        public struct MatrixParameters
        {
            public MatrixParameters( int matrixHeight, int matrixWidth )
            {
                MatrixHeight = matrixHeight;
                MatrixWidth = matrixWidth;
            }

            public int MatrixHeight;
            public int MatrixWidth;
        }

        static void Main( string[] args )
        {
            var input = File.ReadAllLines( "../../../input.txt" );
            var matrixParameters = new MatrixParameters( 0, 0 );
            var matrix = GetMatrix( input, ref matrixParameters );
            var points = GetPaintPoints( matrix, matrixParameters );
            matrix = Paint( matrix, matrixParameters, points );
            WriteInOutputFile( matrix, "../../../output.txt" );

        }

        public static List<List<char>> GetMatrix( string[] inputData, ref MatrixParameters matrixParameters )
        {
            var matrix = new List<List<char>>();
            matrixParameters.MatrixHeight = 0;

            foreach( var line in inputData )
            {
                if( matrixParameters.MatrixHeight <= MaxMatrixSize )
                {
                    var tempLine = new List<char>();
                    matrixParameters.MatrixWidth = 0;

                    foreach( var symbol in line )
                    {
                        if( matrixParameters.MatrixWidth <= MaxMatrixSize )
                        {
                            tempLine.Add( symbol );
                            matrixParameters.MatrixWidth++;
                        }
                    }
                    matrix.Add( tempLine );
                    matrixParameters.MatrixHeight++;
                }
            }

            return matrix;
        }

        public static List<Point> GetPaintPoints( List<List<char>> matrix, MatrixParameters matrixParameters )
        {
            var points = new List<Point>();

            for( int i = 0; i < matrixParameters.MatrixHeight; i++ )
            {
                for( int j = 0; j < matrixParameters.MatrixWidth; j++ )
                {
                    if( matrix[ i ][ j ] == 'O' )
                    {
                        points.Add( new Point( i, j ) );
                    }
                }
            }

            return points;
        }

        public static List<List<char>> Paint( List<List<char>> matrix, MatrixParameters matrixParameters, List<Point> points )
        {
            var fullMatrix = GetFullSizeMatrix( matrix, matrixParameters );

            foreach( var point in points )
            {
                PaintFromPoint( fullMatrix, point );
            }

            return ( fullMatrix );
        }

        public static List<List<char>> GetFullSizeMatrix( List<List<char>> matrix, MatrixParameters matrixParameters )
        {
            var fullMatrix = new List<List<char>>();

            for( int i = 0; i <= MaxMatrixSize; i++ )
            {
                var tempLine = new List<char>();

                for( int j = 0; j <= MaxMatrixSize; j++ )
                {
                    if( matrixParameters.MatrixHeight <= i )
                    {
                        tempLine.Add( ' ' );
                    }
                    else
                    {
                        if( matrixParameters.MatrixWidth <= j )
                        {
                            tempLine.Add( ' ' );
                        }
                        else
                        {
                            tempLine.Add( matrix[ i ][ j ] );
                        }
                    }
                }

                fullMatrix.Add( tempLine );
            }

            return fullMatrix;
        }

        public static void PaintFromPoint( List<List<char>> matrix, Point point )
        {
            var queue = new Queue<Point>();
            queue.Enqueue( point );

            while( queue.ToArray().Length != 0 )
            {
                var element = queue.Dequeue();
                if( matrix[ element.Y ][ element.X ] != 'O' )
                    matrix[ element.Y ][ element.X ] = '.';

                GoRight( element, matrix, queue );
                GoDown( element, matrix, queue );
                GoLeft( element, matrix, queue );
                GoUp( element, matrix, queue );
            }
        }

        static void GoRight( Point element, List<List<char>> matrix, Queue<Point> queu )
        {
            if( element.X < MaxMatrixSize )
            {
                if( matrix[ element.Y ][ element.X + 1 ] == ' ' )
                {
                    if ( !queu.ToList().Contains( new Point( element.Y, element.X + 1 ) ) )
                        queu.Enqueue( new Point( element.Y, element.X + 1 ) );
                }
            }
        }

        static void GoDown( Point element, List<List<char>> matrix, Queue<Point> queu )
        {
            if( element.Y < MaxMatrixSize )
            {
                if( matrix[ element.Y + 1 ][ element.X ] == ' ' )
                {
                    if ( !queu.ToList().Contains( new Point( element.Y + 1, element.X ) ) )
                        queu.Enqueue( new Point( element.Y + 1, element.X ) );
                }
            }
        }

        static void GoLeft( Point element, List<List<char>> matrix, Queue<Point> queu )
        {
            if( element.X > 0 )
            {
                if( matrix[ element.Y ][ element.X - 1 ] == ' ' )
                {
                    if ( !queu.ToList().Contains( new Point( element.Y, element.X - 1 ) ) )
                        queu.Enqueue( new Point( element.Y, element.X - 1 ) );
                }
            }
        }

        static void GoUp( Point element, List<List<char>> matrix, Queue<Point> queu )
        {
            if( element.Y > 0 )
            {
                if( matrix[ element.Y - 1 ][ element.X ] == ' ' )
                {
                    if ( !queu.ToList().Contains( new Point( element.Y - 1, element.X ) ) ) { }
                        queu.Enqueue( new Point( element.Y - 1, element.X ) );
                }
            }
        }


        public static void WriteInOutputFile( List<List<char>> result, string filePath )
        {
            StreamWriter streamWriter = File.CreateText( filePath );
            foreach( var line in result )
            {
                foreach( var element in line )
                {
                    streamWriter.Write( element );
                }
                streamWriter.WriteLine();
            }
            streamWriter.Close();
        }
    }
}
