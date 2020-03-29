using NASA.Enums;
using System;

namespace NASA
{
    public class Position
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public CompassPoint FacingDirection { get; set; }

        public Position(int x, int y, CompassPoint facingDirection)
        {
            XCoordinate = x;
            YCoordinate = y;
            FacingDirection = facingDirection;
        }

        public void UpdatePosition(Move move)
        {
            switch (move)
            {
                case Move.L:
                    TurnLeft();
                    break;

                case Move.R:
                    TurnRight();
                    break;

                case Move.M:
                    MoveForward();
                    break;

                default:
                    throw new ArgumentException("The provided move is not recognized by the system.");
            }
        }        

        private void TurnLeft()
        {
            switch (FacingDirection)
            {
                case CompassPoint.N:
                    FacingDirection = CompassPoint.W;
                    break;

                case CompassPoint.E:
                    FacingDirection = CompassPoint.N;
                    break;

                case CompassPoint.S:
                    FacingDirection = CompassPoint.E;
                    break;

                case CompassPoint.W:
                    FacingDirection = CompassPoint.S;
                    break;
            }
        }
        private void TurnRight()
        {
            switch (FacingDirection)
            {
                case CompassPoint.N:
                    FacingDirection = CompassPoint.E;
                    break;

                case CompassPoint.E:
                    FacingDirection = CompassPoint.S;
                    break;

                case CompassPoint.S:
                    FacingDirection = CompassPoint.W;
                    break;

                case CompassPoint.W:
                    FacingDirection = CompassPoint.N;
                    break;
            }
        }
        private void MoveForward()
        {
            switch (FacingDirection)
            {
                case CompassPoint.N:
                    YCoordinate++;
                    break;

                case CompassPoint.E:
                    XCoordinate++;
                    break;

                case CompassPoint.S:
                    YCoordinate--;
                    break;

                case CompassPoint.W:
                    XCoordinate--;
                    break;
            }
        }
    }
}
