using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Fill
{
    public enum WasError : int
    {
        NoError = 1,
        InvalidCountOfParamsError = 2,
        InputFileNotFoundError = 3
    }

    public static class Program
    {
        const string Backslash = @"\";
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

        public struct ImageParameters
        {
            public ImageParameters( int imageHeight, int imageWidth )
            {
                ImageHeight = imageHeight;
                ImageWidth = imageWidth;
            }

            public int ImageHeight;
            public int ImageWidth;
        }

        static void Main( string[] args )
        {
            var inputData = new string[] { };
            var outputFilePath = "";
            WasError wasError = ReadInputParameters( args, ref inputData, ref outputFilePath );

            if( wasError == WasError.NoError )
            {
                var imageParameters = new ImageParameters( 0, 0 );
                var matrix = GetMatrix( inputData, ref imageParameters );
                var points = GetPaintPoints( matrix, imageParameters );
                matrix = Paint( matrix, imageParameters, points );
                WriteMatrixInOutputFile( matrix, outputFilePath );
            }
            else
            {
                WriteErrorInOutputFile( wasError, outputFilePath );
            }
        }

        public static List<List<char>> GetMatrix( string[] inputData, ref ImageParameters imageParameters )
        {
            var matrix = new List<List<char>>();
            imageParameters.ImageHeight = 0;
            var maxImageWidth = 0;

            foreach( var line in inputData )
            {
                if( imageParameters.ImageHeight <= MaxMatrixSize )
                {
                    var tempLine = new List<char>();
                    imageParameters.ImageWidth = 0;

                    foreach( var symbol in line )
                    {
                        if( imageParameters.ImageWidth <= MaxMatrixSize )
                        {
                            tempLine.Add( symbol );
                            imageParameters.ImageWidth++;
                            if( imageParameters.ImageWidth > maxImageWidth )
                            {
                                maxImageWidth = imageParameters.ImageWidth;
                            }
                        }
                    }
                    matrix.Add( tempLine );
                    imageParameters.ImageHeight++;
                }
            }
            var newMatrix = FillMatrix( matrix, maxImageWidth );

            return newMatrix;
        }

        public static List<List<char>> FillMatrix( List<List<char>> matrix, int maxImageWidth )
        {
            var newMatrix = new List<List<char>>();
            foreach( var line in matrix )
            {
                var counter = 0;
                List<char> tempLine = new List<char>();
                foreach( var element in line )
                {
                    if( counter == line.Count - 1 )
                    {
                        while( counter != maxImageWidth - 1 )
                        {
                            tempLine.Add( ' ' );
                            counter++;
                        }
                    }
                    tempLine.Add( element );
                    counter++;
                }
                newMatrix.Add( tempLine );
            }

            return newMatrix;
        }

        public static List<Point> GetPaintPoints( List<List<char>> matrix, ImageParameters imageParameters )
        {
            var points = new List<Point>();

            for( int i = 0; i < imageParameters.ImageHeight; i++ )
            {
                for( int j = 0; j < imageParameters.ImageWidth; j++ )
                {
                    if( matrix[ i ][ j ] == 'O' )
                    {
                        points.Add( new Point( i, j ) );
                    }
                }
            }

            return points;
        }

        public static List<List<char>> Paint( List<List<char>> matrix, ImageParameters imageParameters, List<Point> points )
        {
            var fullMatrix = GetFullSizeMatrix( matrix, imageParameters );

            foreach( var point in points )
            {
                PaintFromPoint( fullMatrix, point );
            }

            return ( fullMatrix );
        }

        public static List<List<char>> GetFullSizeMatrix( List<List<char>> matrix, ImageParameters imageParameters )
        {
            var fullMatrix = new List<List<char>>();

            for( int i = 0; i <= MaxMatrixSize; i++ )
            {
                var tempLine = new List<char>();

                for( int j = 0; j <= MaxMatrixSize; j++ )
                {
                    if( imageParameters.ImageHeight <= i )
                    {
                        tempLine.Add( ' ' );
                    }
                    else
                    {
                        if( imageParameters.ImageWidth <= j )
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
            while( queue.Count() != 0 )
            {
                var element = queue.Dequeue();

                if( matrix[ element.Y ][ element.X ] != 'O' )
                    matrix[ element.Y ][ element.X ] = '.';
                if( matrix[ element.Y ][ element.X ] == '.' )
                    continue;
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
                    var point = new Point( element.Y, element.X + 1 );
                    queu.Enqueue( point );
                }
            }
        }

        static void GoDown( Point element, List<List<char>> matrix, Queue<Point> queu )
        {
            if( element.Y < MaxMatrixSize )
            {
                if( matrix[ element.Y + 1 ][ element.X ] == ' ' )
                {
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
                    var point = new Point( element.Y, element.X - 1 );
                    queu.Enqueue( point );
                }
            }
        }

        static void GoUp( Point element, List<List<char>> matrix, Queue<Point> queu )
        {
            if( element.Y > 0 )
            {
                if( matrix[ element.Y - 1 ][ element.X ] == ' ' )
                {
                    var point = new Point( element.Y - 1, element.X );
                    queu.Enqueue( point );
                }
            }
        }

        public static void WriteMatrixInOutputFile( List<List<char>> result, string filePath )
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

        public static void WriteErrorInOutputFile( WasError error, string filePath )
        {
            StreamWriter streamWriter = File.CreateText( filePath );

            switch( error )
            {
                case WasError.InputFileNotFoundError:
                {
                    streamWriter.Write( "Input file not found " );
                    break;
                }
                case WasError.InvalidCountOfParamsError:
                {
                    streamWriter.Write( "Invalid count of parameters " );
                    break;
                }
            }

            streamWriter.Close();
        }

        public static WasError ReadInputParameters( string[] args, ref string[] inputData, ref string outputFilePath )
        {
            WasError wasError = WasError.NoError;
            string inputFilePath;
            if( args.Count() != 2 )
            {
                return WasError.InvalidCountOfParamsError;
            }

            inputFilePath = Directory.GetCurrentDirectory() + Backslash + args[ 0 ];
            outputFilePath = Directory.GetCurrentDirectory() + Backslash + args[ 1 ];

            if( File.Exists( inputFilePath ) )
            {
                inputData = File.ReadAllLines( inputFilePath );
            }
            else if( wasError == WasError.NoError )
            {
                return WasError.InputFileNotFoundError;
            }

            return wasError;
        }
    }
}