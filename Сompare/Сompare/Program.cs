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
            if( args.Count() != 2 )
                throw new Exception( "Invalid count of parameters " );

            var inputFilePath = Directory.GetCurrentDirectory() + backslash + args[ 0 ];
            var outputFilePath = Directory.GetCurrentDirectory() + backslash + args[ 1 ];

            if( inputFilePath != outputFilePath )
                CompareFiles( inputFilePath, outputFilePath );
            else
                Console.WriteLine( "Files are equals" );
        }

        public static void CompareFiles( string inputFilePath, string outputFilePath )
        {
            var filesAreEquals = true;
            var lineCounter = 1;

            if( !File.Exists( inputFilePath ) || !File.Exists( outputFilePath ) )
                throw new ArgumentException( "Unable to read the file" );

            StreamReader firstFileReader = new StreamReader( inputFilePath );
            StreamReader secondFileReader = new StreamReader( outputFilePath );

            while( filesAreEquals == true )
            {
                var firstFileLine = firstFileReader.ReadLine();
                var secondFileLine = secondFileReader.ReadLine();

                if( !FileSizesAreDifferent( ref firstFileLine, ref secondFileLine ) )
                    filesAreEquals = false;

                if( firstFileLine != secondFileLine )
                {
                    Console.Write( "Files are different. Line number is " + lineCounter );
                    filesAreEquals = false;
                }

                lineCounter++;

                if( firstFileLine == null )
                    break;
            }

            if( filesAreEquals != false )
                Console.Write( "Files are equal" );
        }

        public static bool FileSizesAreDifferent( ref string firstFileLine, ref string secondFileLine )
        {
            if( ( firstFileLine == null && secondFileLine != null ) || ( firstFileLine != null && secondFileLine == null ) )
                return false;

            return true;
        }
    }
}
