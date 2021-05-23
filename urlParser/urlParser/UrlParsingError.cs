using System;

namespace urlParser
{
    public class UrlParsingError : ArgumentException
    {
        public UrlParsingError( string message ) : base( message )
        {
        }
    }
}
