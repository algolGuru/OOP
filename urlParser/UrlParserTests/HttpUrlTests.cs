using urlParser;
using Xunit;

namespace UrlParserTests
{
    public class HttpUrlTests
    {
        public const string HttpProtocol = "http";
        public const uint HttpPort = 80;
        public const string HttpsProtocol = "https";
        public const uint HttpsPort = 443;

        [Fact]
        public void ParseUrl_ParseValidUrlWithHttpProtocol_ReturnsValidParams()
        {
            //Arrange
            var domain = "domain";
            var document = "docs/img/myimg.png";
            var url = $"{HttpProtocol}://{domain}/{document}";

            // Act 
            var parsedUrl = new HttpUrl( url );

            // Assert
            Assert.Equal( Protocol.HTTP, parsedUrl.GetProtocol() );
            Assert.Equal( domain, parsedUrl.GetDomain() );
            Assert.Equal( HttpPort, parsedUrl.GetPort() );
            Assert.Equal( '/' + document, parsedUrl.GetDocument() );
        }

        [Fact]
        public void ParseUrl_ParseValidUrlWithHttpsProtocol_ReturnsValidParams()
        {
            //Arrange
            var domain = "domain";
            var document = "docs/img/myimg.png";
            var url = $"{HttpsProtocol}://{domain}/{document}";

            // Act 
            var parsedUrl = new HttpUrl( url );

            // Assert
            Assert.Equal( Protocol.HTTPS, parsedUrl.GetProtocol() );
            Assert.Equal( domain, parsedUrl.GetDomain() );
            Assert.Equal( HttpsPort, parsedUrl.GetPort() );
            Assert.Equal( '/' + document, parsedUrl.GetDocument() );
        }

        [Fact]
        public void ParseUrl_ParseValidUrlWithInvalidProtocol_ReturnsUrlParseExeption()
        {
            //Arrange
            var domain = "domain";
            var document = "docs/img/myimg.png";
            var url = $"htttp://{domain}/{document}";

            // Act & Assert
            Assert.Throws<UrlParsingError>( () => new HttpUrl( url ) );
        }

        [Fact]
        public void ParseUrl_ParseValidUrlWithInvaidDomain_ReturnsUrlParseExeption()
        {
            //Arrange
            var domain = "";
            var document = "docs/img/myimg.png";
            var url = $"htttp://{domain}/{document}";

            // Act & Assert
            Assert.Throws<UrlParsingError>( () => new HttpUrl( url ) );
        }

        [Fact]
        public void ParseUrl_ParseValidUrlWithCustomPort_ReturnsUrlWithThisProtocol()
        {
            //Arrange
            var domain = "domain";
            var document = "docs/img/myimg.png";
            uint port = 4200;
            var url = $"{HttpsProtocol}://{domain}:{port}/{document}";

            // Act 
            var parsedUrl = new HttpUrl( url );
            
            //Assert
            Assert.Equal( Protocol.HTTPS, parsedUrl.GetProtocol() );
            Assert.Equal( domain, parsedUrl.GetDomain() );
            Assert.Equal( port, parsedUrl.GetPort() );
            Assert.Equal( '/' + document, parsedUrl.GetDocument() );
        }

        [Fact]
        public void ParseUrl_ParseUrlWithoutDomain_ReturnsUrlParseExeption()
        {
            //Arrange
            var domain = "";
            var document = "docs/img/myimg.png";
            var url = $"{HttpsProtocol}://{domain}/{document}";

            // Act & Assert
            Assert.Throws<UrlParsingError>( () => new HttpUrl( url ) );
        }

        [Fact]
        public void ParseUrl_ParseUrlWithInvalidUrlFormat_ReturnsUrlParseExeption()
        {
            //Arrange
            var domain = "";
            var document = "docs/img/myimg.png";
            uint port = 4200;
            var url = $"{HttpsProtocol}://{domain}::{port}/{document}";

            // Act & Assert
            Assert.Throws<UrlParsingError>( () => new HttpUrl( url ) );
        }

        [Fact]
        public void ParseUrl_ParseValidUrlWithOutDocument_ReturnsValidUrlWithOutDocument()
        {
            //Arrange
            var domain = "domain";
            var document = "";
            var url = $"{HttpProtocol}://{domain}/{document}";

            // Act 
            var parsedUrl = new HttpUrl( url );

            // Assert
            Assert.Equal( Protocol.HTTP, parsedUrl.GetProtocol() );
            Assert.Equal( domain, parsedUrl.GetDomain() );
            Assert.Equal( HttpPort, parsedUrl.GetPort() );
            Assert.Equal( '/' + document, parsedUrl.GetDocument() );
        }

        [Fact]
        public void ParseUrl_ParseValidUrlWithDocumentAndGetParams_ReturnsValidUrlWithDocument()
        {
            //Arrange
            var domain = "domain";
            var document = "docs/img/myimg.png";
            var url = $"{HttpProtocol}://{domain}/{document}?count=100";

            // Act 
            var parsedUrl = new HttpUrl( url );

            // Assert
            Assert.Equal( Protocol.HTTP, parsedUrl.GetProtocol() );
            Assert.Equal( domain, parsedUrl.GetDomain() );
            Assert.Equal( HttpPort, parsedUrl.GetPort() );
            Assert.Equal( '/' + document, parsedUrl.GetDocument() );
        }

        [Fact]
        public void ParseUrl_ParseWithDomainAndDocument_ReturnsValidUrl()
        {
            //Arrange
            var domain = "domain";
            var document = "docs/img/myimg.png";

            // Act 
            var parsedUrl = new HttpUrl( domain, document );

            // Assert
            Assert.Equal( Protocol.HTTP, parsedUrl.GetProtocol() );
            Assert.Equal( domain, parsedUrl.GetDomain() );
            Assert.Equal( HttpPort, parsedUrl.GetPort() );
            Assert.Equal( '/' + document, parsedUrl.GetDocument() );
        }

        [Fact]
        public void ParseUrl_ParseWithDomainAndDocumentAndHttpProtocol_ReturnsValidUrl()
        {
            //Arrange
            var domain = "domain";
            var document = "docs/img/myimg.png";
            var protocol = Protocol.HTTPS;

            // Act 
            var parsedUrl = new HttpUrl( domain, document, protocol );

            // Assert
            Assert.Equal( Protocol.HTTPS, parsedUrl.GetProtocol() );
            Assert.Equal( domain, parsedUrl.GetDomain() );
            Assert.Equal( HttpsPort, parsedUrl.GetPort() );
            Assert.Equal( '/' + document, parsedUrl.GetDocument() );
        }

        [Fact]
        public void ParseUrl_ParseWithInvalidDomainAndDocument_ReturnsUrlParseExeption()
        {
            //Arrange
            var domain = "";
            var document = "docs/img/myimg.png";
            var protocol = Protocol.HTTPS;

            // Act & Assert
            Assert.Throws<UrlParsingError>( () => new HttpUrl( domain, document, protocol ) );
        }

        [Fact]
        public void ParseUrl_ParseWithDomainAndDocumentAndProtocolAndPortDifferentFromStandart_ReturnsValidUrlWithDifferentPort()
        {
            //Arrange
            var domain = "domain";
            var document = "docs/img/myimg.png";
            var protocol = Protocol.HTTP;
            uint port = 4200;

            // Act 
            var parsedUrl = new HttpUrl( domain, document, protocol, port );

            // Assert
            Assert.Equal( Protocol.HTTP, parsedUrl.GetProtocol() );
            Assert.Equal( domain, parsedUrl.GetDomain() );
            Assert.Equal( port, parsedUrl.GetPort() );
            Assert.Equal( '/' + document, parsedUrl.GetDocument() );
        }

        [Fact]
        public void ParseUrl_ParseWithInvalidPort_ReturnsUrlParseExeption()
        {
            //Arrange
            var domain = "";
            var document = "docs/img/myimg.png";
            var protocol = Protocol.HTTPS;
            uint port = 65536;

            // Act & Assert
            Assert.Throws<UrlParsingError>( () => new HttpUrl( domain, document, protocol, port ) );
        }

        [Fact]
        public void ParseUrl_ParseValidUrlWithInvalidPort_ReturnsUrlParseExeption()
        {
            //Arrange
            var domain = "domain";
            var document = "docs/img/myimg.png";
            uint port = 0;
            var url = $"{HttpsProtocol}://{domain}:{port}/{document}";

            // Act & Assert
            Assert.Throws<UrlParsingError>( () => new HttpUrl( url ) );
        }

        [Fact]
        public void ParseUrl_ParseValidUrlWithValidPort1_ReturnsValidParams()
        {
            //Arrange
            var domain = "domain";
            var document = "docs/img/myimg.png";
            uint port = 1;
            var url = $"{HttpProtocol}://{domain}:{port}/{document}";

            // Act 
            var parsedUrl = new HttpUrl( url );

            // Assert
            Assert.Equal( Protocol.HTTP, parsedUrl.GetProtocol() );
            Assert.Equal( domain, parsedUrl.GetDomain() );
            Assert.Equal( port, parsedUrl.GetPort() );
            Assert.Equal( '/' + document, parsedUrl.GetDocument() );
        }

        [Fact]
        public void ParseUrl_ParseValidUrlWithValidPort65535_ReturnsValidParams()
        {
            //Arrange
            var domain = "domain";
            var document = "docs/img/myimg.png";
            uint port = 65535;
            var url = $"{HttpProtocol}://{domain}:{port}/{document}";

            // Act 
            var parsedUrl = new HttpUrl( url );

            // Assert
            Assert.Equal( Protocol.HTTP, parsedUrl.GetProtocol() );
            Assert.Equal( domain, parsedUrl.GetDomain() );
            Assert.Equal( port, parsedUrl.GetPort() );
            Assert.Equal( '/' + document, parsedUrl.GetDocument() );
        }
    }
}