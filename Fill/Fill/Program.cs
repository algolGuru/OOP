using Fill.Files;

namespace Fill
{
    class Program
    {
        static void Main( string[] args )
        {
            FileReader fileReader = new FileReader( "../../../input.txt" );
            var input = fileReader.GetFileText();

            RunProgram run = new RunProgram();
            var result = run.Run( input );

            FileWriter fileWriter = new FileWriter( "../../../output.txt" );
            fileWriter.GetOutput( result );
        }
    }
}
