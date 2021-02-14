using Fill.Matrices;
using Fill.Points;
using System.Collections.Generic;

namespace Fill
{
    public class MatrixPainter
    {
        public MatrixPainter( Matrix matrix )
        {
            Matrix = matrix;
        }

        private Matrix Matrix;

        public List<List<char>> PaintMatrix( Dictionary<int, Point> pointsList )
        {
            var matrix = Matrix.GetMatrix();

            DrawFromPoints( pointsList, matrix );
            FinishDrawingIfRecursiveIsBlock( matrix );

            return Matrix.GetMatrix();
        }

        private void DrawFromPoints( Dictionary<int, Point> pointsList, List<List<char>> matrix )
        {
            foreach( var point in pointsList.Values )
            {
                var recursiveCounter = 0;
                Paint( point, recursiveCounter, matrix );
                matrix[ point.Y ][ point.X ] = '0';
            }
        }

        private void FinishDrawingIfRecursiveIsBlock( List<List<char>> matrix )
        {
            for( int i = 0; i < 10; i++ )
            {
                for( int j = 0; j < 100; j++ )
                {
                    for( int k = 0; k < 100; k++ )
                    {
                        var recursiveCounter = 0;
                        if( matrix[ j ][ k ] == '.' )
                        {
                            matrix[ j ][ k ] = ' ';
                            Paint( new Point( k, j ), recursiveCounter, matrix );
                        }
                    }
                }
            }
        }

        private int Paint( Point point, int recursiveCounter, List<List<char>> matrix )
        {
            recursiveCounter++;
            if( recursiveCounter >= 100 )
                return recursiveCounter;

            PaintPoint( point, recursiveCounter, matrix );

            return recursiveCounter;
        }

        private void PaintPoint( Point point, int recursiveCounter, List<List<char>> matrix )
        {
            var x = point.X;
            var y = point.Y;
            var matrixSize = Matrix.GetMarixMaxSize() - 1;

            if( ( matrix[ y ][ x ] == ' ' ) || ( ( matrix[ y ][ x ] == 'O' ) && ( recursiveCounter == 1 ) ) )
            {
                matrix[ y ][ x ] = '.';
                if( x != matrixSize )
                {
                    var newPoint = new Point( x + 1, y );
                    recursiveCounter = Paint( newPoint, recursiveCounter, matrix );
                }
                if( x != 0 )
                {
                    var newPoint = new Point( x - 1, y );
                    recursiveCounter = Paint( newPoint, recursiveCounter, matrix );
                }
                if( y != matrixSize )
                {
                    var newPoint = new Point( x, y + 1 );
                    recursiveCounter = Paint( newPoint, recursiveCounter, matrix );
                }
                if( y != 0 )
                {
                    var newPoint = new Point( x, y - 1 );
                    recursiveCounter = Paint( newPoint, recursiveCounter, matrix );
                }
            }
        }
    }
}
