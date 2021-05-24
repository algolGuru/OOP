namespace urlParser
{
    public enum Protocol
    {
        HTTP,
        HTTPS
    };

    public class HttpUrl
    {
        private readonly string _domain;
        private readonly string _document;
        private readonly Protocol _protocol;
        private readonly uint _port;

        private const uint MaxPort = 65535;
        private const uint HttpStandartPort = 80;
        private const uint HttpsStandartPort = 443;

        public HttpUrl( string url )
        {
            _protocol = FindProtocol( ref url );

            var domain = FindDomain( ref url );
            if( !IsDomainValid( domain ) )
            {
                throw new UrlParsingError( "Domain invalid" );
            }
            _domain = domain;

            var port = FindPort( ref url );
            if( !IsValidPort( port ) )
            {
                throw new UrlParsingError( "Port invalid" );
            }
            _port = port;

            var document = FindDocument( ref url );
            _document = ConvertToValidDocument( document );
        }

        public HttpUrl( string domain, string document, Protocol protocol = Protocol.HTTP )
        {
            if( !IsDomainValid( domain ) )
            {
                throw new UrlParsingError( "Domain invalid" );
            }

            _domain = domain;
            _document = ConvertToValidDocument( document );
            _port = GetPortByProtocol( protocol );
            _protocol = protocol;
        }

        public HttpUrl( string domain, string document, Protocol protocol, uint port )
        {
            if( !IsDomainValid( domain ) )
            {
                throw new UrlParsingError( "Domain invalid" );
            }
            if( !IsValidPort( port ) )
            {
                throw new UrlParsingError( "Invalid port" );
            }

            _domain = domain;
            _document = ConvertToValidDocument( document );
            _port = port;
            _protocol = protocol;
        }

        public string GetUrl()
        {
            if( _port != HttpsStandartPort && _port != HttpStandartPort )
            {
                return $"{GetProtocol().ToString().ToLower()}://{GetDomain()}:{GetPort()}{GetDocument()}";
            }
            else
            {
                return $"{GetProtocol().ToString().ToLower()}://{GetDomain()}{GetDocument()}";
            }
        }

        public string GetDomain()
        {
            return _domain;
        }

        public string GetDocument()
        {
            return _document;
        }

        public Protocol GetProtocol()
        {
            return _protocol;
        }

        public uint GetPort()
        {
            return _port;
        }

        private static bool IsDomainValid( string domainString )
        {
            if( domainString != "" )
            {
                return true;
            }

            return false;
        }

        private bool IsValidPort( uint port )
        {
            if( port <= 0 || port > MaxPort )
            {
                return false;
            }

            return true;
        }

        private string ConvertToValidDocument( string document )
        {
            if( document.Length != 0 && document[ 0 ] != '/' )
            {
                return '/' + document;
            }

            return document;
        }

        private uint GetPortByProtocol( Protocol protocol )
        {
            if( protocol == Protocol.HTTP )
            {
                return HttpStandartPort;
            }
            else
            {
                return HttpsStandartPort;
            }
        }

        private static Protocol FindProtocol( ref string url )
        {
            var urlString = url.Split( "://" );
            if( urlString.Length != 2 )
            {
                throw new UrlParsingError( "Invalid format of url" );
            }
            url = urlString[ 1 ];
            var protocol = urlString[ 0 ].ToLower();

            if( protocol == "http" )
            {
                return Protocol.HTTP;
            }
            else if( protocol == "https" )
            {
                return Protocol.HTTPS;
            }

            throw new UrlParsingError( "Invalid protocol" );
        }

        private static string FindDomain( ref string url )
        {
            var urlString = url.Split( ':' );
            if( urlString.Length > 2 )
            {
                throw new UrlParsingError( "Ivalid fromat of url" );
            }
            if( urlString.Length == 1 )
            {
                var newUrlString = url.Split( '/' );
                url = "";
                for( int i = 0; i < newUrlString.Length; i++ )
                {
                    if( i != 0 )
                    {
                        url += '/' + newUrlString[ i ];
                    }
                }
                return newUrlString[ 0 ];
            }
            url = ':' + urlString[ 1 ];
            return urlString[ 0 ];
        }

        private uint FindPort( ref string url )
        {
            if( !url.Contains( ':' ) )
            {
                return GetPortByProtocol( _protocol );
            }
            else
            {
                var urlString = url.Split( ':' );
                if( urlString.Length != 2 )
                {
                    throw new UrlParsingError( "Invalid format of url" );
                }
                url = urlString[ 1 ];
                var newUrlString = url.Split( '/' );
                url = "";
                for( int i = 0; i < newUrlString.Length; i++ )
                {
                    if( i != 0 )
                    {
                        url += '/' + newUrlString[ i ];
                    }
                }
                try
                {
                    return uint.Parse( newUrlString[ 0 ] );
                }
                catch
                {
                    throw new UrlParsingError( "Invalid port" );
                }
            }
        }

        private static string FindDocument( ref string url )
        {
            var urlString = url.Split( '?' );
            if( urlString.Length > 2 )
            {
                throw new UrlParsingError( "Invalid format of url" );
            }
            return urlString[ 0 ];
        }
    }
}
