using System;
using System.IO;
using System.Linq;

namespace oopLW
{
    class Program
    {
        const string backslash = @"\";

        static void Main( string[] args )
        {
            if( args.Count() != 2 )
            {
                throw new Exception( "Invalid count of parameters " );
            }

            var inputFilePath = Directory.GetCurrentDirectory() + backslash + args[ 0 ];
            var outputFilePath = Directory.GetCurrentDirectory() + backslash + args[ 1 ];

            if( inputFilePath != outputFilePath )
            {
                try
                {
                    CopyFile( inputFilePath, outputFilePath );
                }
                catch( Exception )
                {
                    throw new ArgumentException( "unable to copy file" );
                }
            }
        }

        private static void CopyFile( string inputFilePath, string outputFilePath )
        {
            var outputFile = File.CreateText( outputFilePath );
            var inputFile = new StreamReader( inputFilePath );

            while( !inputFile.EndOfStream )
            {
                var line = inputFile.ReadLine();

                outputFile.Write( line );
                if( line.Contains( '\n' ) )
                {
                    outputFile.WriteLine();
                }
            }

            outputFile.Close();
        }
    }
}
