using System;
using System.Collections.Generic;

namespace HtmlDecode
{
    public class HtmlDecoder
    {
        public List<string> DecodeAllHtmlText( List<string> text )
        {
            for( int i = 0; i < text.Count; i++ )
            {
                text[ i ] = HtmlDecode( text[ i ] );
            }

            return text;
        }
        
        public string HtmlDecode( string html )
        {
            if( html.Contains( "&quot;" ) )
            {
                html = html.Replace( "&quot;", "\"" );
            }
            if( html.Contains( "&apos;" ) )
            {
                html = html.Replace( "&apos;", "'" );
            }
            if( html.Contains( "&lt;" ) )
            {
                html = html.Replace( "&lt;", "<" );
            }
            if( html.Contains( "&gt;" ) )
            {
                html = html.Replace( "&gt;", ">" );
            }
            if( html.Contains( "&amp;" ) )
            {
                html = html.Replace( "&amp;", "&" );
            }

            return html;
        }
    }

    class Program
    {
        static void Main( string[] args )
        {
            var inputText = ReadInputInList();

            HtmlDecoder htmlDecoder = new HtmlDecoder();
            List<string> result = htmlDecoder.DecodeAllHtmlText( inputText );

            WriteOutput( result );
        }

        public static List<string> ReadInputInList()
        {
            string line;
            var inputText = new List<string>();
            while( !string.IsNullOrWhiteSpace( line = Console.ReadLine() ) )
            {
                inputText.Add( line );
            }

            return inputText;
        }

        public static void WriteOutput( List<string> output )
        {
            foreach( var line in output )
            {
                Console.WriteLine( line );
            }
        }
    }
}
