using System.Collections.Generic;

namespace Fill.Points
{
    public class PointsFinder
    {
        private Dictionary<int, Point> StartPoints = new Dictionary<int, Point> { };

        public Dictionary<int, Point> FindAllPoints( List<List<char>> matrix, int matrixWidth, int matrixHeight )
        {
            var counter = 0;
            for( int i = 0; i < matrixHeight; i++ )
            {
                for( int j = 0; j < matrixWidth; j++ )
                {
                    if( matrix[ i ][ j ] == 'O' )
                    {
                        counter++;
                        StartPoints.Add( counter, new Point( j, i ) );
                    }
                }
            }

            return StartPoints;
        }

    }
}
