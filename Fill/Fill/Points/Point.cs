namespace Fill.Points
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X;
        public int Y;

        public Point SetPosition(int x, int y)
        {
            return new Point( x, y );
        }

        public int GetXPosition()
        {
            return X;
        }

        public int GetYPosition()
        {
            return Y;
        }
    }
}
