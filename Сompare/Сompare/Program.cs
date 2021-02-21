using System;
using System.IO;
using System.Linq;

namespace Сompare
{
    class Program
    {
        const string backslash = @"\";

        static void Main( string[] args )
        {
            if( args.Count() < 2 || args.Count() > 2 )
                throw new Exception( "Invalid count of parameters " );

            var inputFilePath = Directory.GetCurrentDirectory() + backslash + args[ 0 ];
            var outputFilePath = Directory.GetCurrentDirectory() + backslash + args[ 1 ];

            Console.WriteLine( inputFilePath );

            if( inputFilePath != outputFilePath )
                CompareFiles( inputFilePath, outputFilePath );
        }

        public static void CompareFiles( string inputFilePath, string outputFilePath )
        {
            try
            {
                var inputData = File.ReadAllLines( inputFilePath );
                var outputFile = File.ReadAllLines( outputFilePath );

                CompareTexts( inputData, outputFile );
            }
            catch( Exception exeption )
            {
                throw exeption;
            }
        }

        public static bool CompareTexts( string[] fileText1, string[] fileText2 )
        {
            var isEquals = true;

            for( int i = 0; i < fileText1.Length; i++ )
            {
                if( fileText1[ i ] != fileText2[ i ] )
                {
                    Console.WriteLine( @"Files are different. Line number is {i}" );
                    isEquals = false;
                }
            }
            if( isEquals )
                Console.WriteLine( "Files are equal" );
            return isEquals;
        }
    }
}
