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

            if( args.Count() < 2 || args.Count() > 2 )
                throw new Exception( "Invalid count of parameters " );

            var inputFilePath = Directory.GetCurrentDirectory() + backslash + args[ 0 ];
            var outputFilePath = Directory.GetCurrentDirectory() + backslash + args[ 1 ];

            if( inputFilePath != outputFilePath )
                CopyFile( inputFilePath, outputFilePath );
        }

        private static void CopyFile( string inputFilePath, string outputFilePath )
        {
            try
            {
                var inputData = File.ReadAllLines( inputFilePath );
                var outputFile = File.CreateText( outputFilePath );

                CopyTextInFile( inputData, outputFile );
                outputFile.Close();
            }
            catch( Exception exeption )
            {
                throw exeption;
            }
        }

        private static void CopyTextInFile( string[] text, StreamWriter file )
        {
            foreach( var inputLine in text )
            {
                file.Write( inputLine );
                if( inputLine.Contains( '\n' ) )
                    file.WriteLine();
            }
        }
    }
}
