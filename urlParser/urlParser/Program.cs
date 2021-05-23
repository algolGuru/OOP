using System;
using System.IO;

namespace urlParser
{
    class Program
    {
        static void Main( string[] args )
        {
            var input = File.ReadAllLines( "../../../input.txt" );

            foreach( var line in input )
            {
                try
                {
                    var url = new HttpUrl( line );
                    Console.WriteLine( "Результат парсинга урла: " + line );
                    Console.WriteLine( "Протокол " + url.GetProtocol().ToString() );
                    Console.WriteLine( "Домен " + url.GetDomain() );
                    Console.WriteLine( "Порт " + url.GetPort() );
                    Console.WriteLine( "Документ " + url.GetDocument() );
                    Console.WriteLine();
                }
                catch( UrlParsingError error )
                {
                    Console.WriteLine( "Результат парсинга урла: " + line );
                    Console.WriteLine( error.Message );
                    Console.WriteLine( );
                }
            }
        }
    }
}
