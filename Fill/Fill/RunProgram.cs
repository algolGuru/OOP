using Fill.Matrices;
using Fill.Points;
using System.Collections.Generic;

namespace Fill
{
    public class RunProgram
    {
        public List<List<char>> Run( string[] input )
        {
            var matrix = GetMatrixFromInput( input );
            var points = GetPrinPoints( matrix );
            var matrixPainter = new MatrixPainter( matrix );

            return matrixPainter.PaintMatrix( points );
        }

        private Matrix GetMatrixFromInput( string[] input )
        {
            MatrixCreator matrixCreator = new MatrixCreator( input );
            var matrix = matrixCreator.GetMatrix();

            return matrix;
        }

        private Dictionary<int, Point> GetPrinPoints( Matrix matrix )
        {
            PointsFinder pointFinder = new PointsFinder();
            var points = pointFinder.FindAllPoints( matrix.GetMatrix(), matrix.GetMatrixWidth(), matrix.GetMatrixHeight() );

            return points;
        }
    }
}
