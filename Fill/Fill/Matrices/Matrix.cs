using System.Collections.Generic;

namespace Fill.Matrices
{
    public class Matrix
    {
        public Matrix( List<List<char>> inputMatrix, int matrixMaxSize, int matrixWidth, int matrixHeight )
        {
            InputMatrix = inputMatrix;
            MatrixMaxSize = matrixMaxSize;
            MatrixWidth = matrixWidth;
            MatrixHeight = matrixHeight;
        }

        private List<List<char>> InputMatrix;
        private int MatrixMaxSize;
        private int MatrixWidth;
        private int MatrixHeight;

        public List<List<char>> GetMatrix()
        {
            return InputMatrix;
        }

        public int GetMarixMaxSize()
        {
            return MatrixMaxSize;
        }

        public int GetMatrixWidth()
        {
            return MatrixWidth;
        }

        public int GetMatrixHeight()
        {
            return MatrixHeight;
        }
    }
}
