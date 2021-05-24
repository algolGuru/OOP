using System;

namespace urlParser
{
    class Program
    {
        static void Main( string[] args )
        {
            Console.WriteLine( "Введите урлы" );
            Console.WriteLine( "ctr + z - конец файла" );
            string line;
            do
            {
                line = Console.ReadLine();
                if( line != null )
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
                        Console.WriteLine();
                    }
                }
            } while( line != null );
        }
    }
}
