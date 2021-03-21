using System;
using System.Collections.Generic;
using Xunit;

namespace HtmlDecode.Tests
{
    public class HtmlDecoderTests
    {
        [Fact]
        public void DecodeAllHtmlText_DecodeTextWithHtmlSymbols_DecodedText()
        {
            //Arrange
            HtmlDecoder htmlDecoder = new HtmlDecoder();
            List<string> textForDecode = new List<string> { "Cat &lt;says&gt; &quot;Meow&quot;. M&amp;M&apos;s" };
            List<string> textAfterDecode = new List<string> { "Cat <says> \"Meow\". M&M's" };

            //Act
            var htmlDecodeResult = htmlDecoder.DecodeAllHtmlText( textForDecode );

            //Assert
            Assert.True( string.Equals( textAfterDecode[ 0 ], htmlDecodeResult[ 0 ] ) );
        }

        [Fact]
        public void DecodeAllHtmlText_DecodeTextWitoutHtmlSymbols_DecodedText()
        {
            //Arrange
            HtmlDecoder htmlDecoder = new HtmlDecoder();
            List<string> textForDecode = new List<string> { "Cat <> says & meow" };

            //Act
            var htmlDecodeResult = htmlDecoder.DecodeAllHtmlText( textForDecode );

            //Assert
            Assert.True( string.Equals( textForDecode[ 0 ], htmlDecodeResult[ 0 ] ) );
        }
    }
}
