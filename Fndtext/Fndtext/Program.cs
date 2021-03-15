using System;
using System.IO;
using System.Linq;

namespace Fndtext
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

            var inputFilePath = Directory.GetCurrentDirectory() + backslash + args[ 0 ];
            var findingText = args[ 1 ];

            if( File.Exists( inputFilePath ) )
            {
                FindAllOccurrences( inputFilePath, ref findingText );
            }
            else
            {
                Console.WriteLine( "File does not exist" );
                return;
            }
        }

        // string 
        public static void FindAllOccurrences( string inputFilePath, ref string findingText )
        {
            var fileReader = new StreamReader( inputFilePath );
            var countOfLine = 1;
            var textIsContainsInFile = false;
            var lineFromFile = fileReader.ReadLine();

            while( lineFromFile != null )
            {
                if( lineFromFile.Contains( findingText ) )
                {
                    Console.WriteLine( countOfLine );
                    textIsContainsInFile = true;
                }

                lineFromFile = fileReader.ReadLine();
                countOfLine++;
            }

            if( textIsContainsInFile == false )
            {
                Console.WriteLine( "Text not found" );
            }
        }
    }
}
