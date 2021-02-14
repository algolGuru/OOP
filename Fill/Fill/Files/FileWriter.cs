using System.Collections.Generic;
using System.IO;

namespace Fill.Files
{
    public class FileWriter
    {
        public FileWriter( string filePath )
        {
            FilePath = filePath;
        }

        private string FilePath;

        public void GetOutput( List<List<char>> result )
        {
            StreamWriter streamWriter = File.CreateText( FilePath );
            foreach( var line in result )
            {
                foreach( var element in line )
                {
                    streamWriter.Write( element );
                }
                streamWriter.WriteLine(  );
            }
            streamWriter.Close();
        }
    }
}
