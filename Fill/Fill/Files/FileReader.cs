using System.IO;

namespace Fill.Files
{
    public class FileReader
    {
        public FileReader( string filePath )
        {
            FilePath = filePath;
        }

        private string FilePath;

        public string[] GetFileText()
        {
            var fileText = File.ReadAllLines( FilePath );

            return fileText;
        }
    }
}
