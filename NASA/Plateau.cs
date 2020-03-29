namespace NASA
{
    public class Plateau
    {
        private int minXCoordinate => 0;
        private int minYCoordinate => 0;
        private int maxXCoordinate { get; set; }
        private int maxYCoordinate { get; set; }

        public Plateau(int x, int y)
        {
            maxXCoordinate = x;
            maxYCoordinate = y;
        }
        public bool AreCoordinatedInbound(int x, int y)
        {
            if (x > maxXCoordinate)
                return false;

            if (x < minXCoordinate)
                return false;

            if (y > maxYCoordinate)
                return false;

            if (y < minYCoordinate)
                return false;

            return true;
        }
    }
}
