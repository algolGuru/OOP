using System.Collections.Generic;
using System.Linq;

namespace Fill.Matrices
{
    public class MatrixCreator
    {
        private const int FullMatrixSize = 100;

        public MatrixCreator( string[] text )
        {
            SetMatrix( text );
        }

        private Matrix Matrix;

        public int GetWidth()
        {
            return Matrix.GetMatrixWidth();
        }

        public int GetHeight()
        {
            return Matrix.GetMatrixHeight();
        }

        public Matrix GetMatrix()
        {
            return Matrix;
        }

        public int GetFullSize()
        {
            return FullMatrixSize;
        }

        private void SetMatrix( string[] text )
        {
            List<List<char>> matrixFromInput = SetInputMatrix( text );

            var height = SetMatrixHeight( matrixFromInput );
            var width = SetMatrixWidth( matrixFromInput );
            var emptyMatrix = SetEmptyMatrix();
            var fullMatrix = SetFullMatrix( matrixFromInput, emptyMatrix, height, width );

            Matrix = new Matrix( fullMatrix, FullMatrixSize, width, height );
        }

        private List<List<char>> SetInputMatrix( string[] text )
        {
            var tempMatrix = new List<List<char>> { };

            foreach( var line in text )
            {
                var matrixLine = new List<char> { };
                foreach( var symbol in line )
                {
                    matrixLine.Add( symbol );
                }
                tempMatrix.Add( matrixLine );
            }

            return tempMatrix;
        }

        private int SetMatrixHeight( List<List<char>> matrix )
        {
            return matrix.Count();
        }

        private int SetMatrixWidth( List<List<char>> matrix )
        {
            return matrix[ 0 ].Count();
        }

        private List<List<char>> SetEmptyMatrix()
        {
            var matrix = new List<List<char>> { };
            for( int i = 0; i < FullMatrixSize; i++ )
            {
                var matrixLine = new List<char> { };
                for( int j = 0; j < FullMatrixSize; j++ )
                {
                    matrixLine.Add( ' ' );
                }

                matrix.Add( matrixLine );
            }

            return matrix;
        }

        private List<List<char>> SetFullMatrix( List<List<char>> tempMatrix, List<List<char>> destinationMatrix, int matrixHeight, int matrixWidth )
        {
            for( int i = 0; i < FullMatrixSize; i++ )
            {
                for( int j = 0; j < FullMatrixSize; j++ )
                {
                    if( i < matrixHeight && j < matrixWidth )
                        destinationMatrix[ i ][ j ] = tempMatrix[ i ][ j ];
                    else
                        destinationMatrix[ i ][ j ] = ' ';
                }
            }

            return destinationMatrix;
        }
    }
}
