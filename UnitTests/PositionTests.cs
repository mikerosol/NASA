using NASA;
using NASA.Enums;
using NUnit.Framework;

namespace UnitTests
{
    public class PositionTests
    {
        [Test]
        public void TurnLeft()
        {
            var position = new Position(0, 0, CompassPoint.N);

            position.UpdatePosition(Move.L);
            Assert.AreEqual(CompassPoint.W, position.FacingDirection);

            position.UpdatePosition(Move.L);
            Assert.AreEqual(CompassPoint.S, position.FacingDirection);

            position.UpdatePosition(Move.L);
            Assert.AreEqual(CompassPoint.E, position.FacingDirection);

            position.UpdatePosition(Move.L);
            Assert.AreEqual(CompassPoint.N, position.FacingDirection);
        }

        [Test]
        public void TurnRight()
        {
            var position = new Position(0, 0, CompassPoint.N);

            position.UpdatePosition(Move.R);
            Assert.AreEqual(CompassPoint.E, position.FacingDirection);

            position.UpdatePosition(Move.R);
            Assert.AreEqual(CompassPoint.S, position.FacingDirection);

            position.UpdatePosition(Move.R);
            Assert.AreEqual(CompassPoint.W, position.FacingDirection);

            position.UpdatePosition(Move.R);
            Assert.AreEqual(CompassPoint.N, position.FacingDirection);
        }

        [Test]
        public void MoveForward()
        {
            var position = new Position(0, 0, CompassPoint.N);

            position.UpdatePosition(Move.M);
            Assert.AreEqual(0, position.XCoordinate);
            Assert.AreEqual(1, position.YCoordinate);
            Assert.AreEqual(CompassPoint.N, position.FacingDirection);

            position.UpdatePosition(Move.R);
            position.UpdatePosition(Move.M);
            Assert.AreEqual(1, position.XCoordinate);
            Assert.AreEqual(1, position.YCoordinate);
            Assert.AreEqual(CompassPoint.E, position.FacingDirection);

            position.UpdatePosition(Move.R);
            position.UpdatePosition(Move.M);
            Assert.AreEqual(1, position.XCoordinate);
            Assert.AreEqual(0, position.YCoordinate);
            Assert.AreEqual(CompassPoint.S, position.FacingDirection);

            position.UpdatePosition(Move.R);
            position.UpdatePosition(Move.M);
            Assert.AreEqual(0, position.XCoordinate);
            Assert.AreEqual(0, position.YCoordinate);
            Assert.AreEqual(CompassPoint.W, position.FacingDirection);
        }
    }
}