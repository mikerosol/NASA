using NASA;
using NASA.Enums;
using NASA.Exceptions;
using NUnit.Framework;

namespace UnitTests
{
    public class RoverTests
    {
        [Test]
        public void Rover1_SuccessfulMission()
        {
            //ARRANGE
            var plateau = new Plateau(5, 5);
            var startingPosition = new Position(1, 2, CompassPoint.N);
            var rover = new Rover(plateau, startingPosition);

            //ACT
            rover.SubmitMovementPlan("LMLMLMLMM");
            rover.ExecuteMovementPlan();
            var actualEndingPosition  = rover.GetCurrentPosition();

            //ASSERT
            var expectedEndingPosition = new Position(1, 3, CompassPoint.N);
            Assert.AreEqual(expectedEndingPosition.XCoordinate, actualEndingPosition.XCoordinate);
            Assert.AreEqual(expectedEndingPosition.YCoordinate, actualEndingPosition.YCoordinate);
            Assert.AreEqual(expectedEndingPosition.FacingDirection, actualEndingPosition.FacingDirection);
        }

        [Test]
        public void Rover2_SuccessfulMission()
        {
            //ARRANGE
            var plateau = new Plateau(5, 5);
            var startingPosition = new Position(3, 3, CompassPoint.E);
            var rover = new Rover(plateau, startingPosition);

            //ACT
            rover.SubmitMovementPlan("MMRMMRMRRM");
            rover.ExecuteMovementPlan();
            var actualEndingPosition = rover.GetCurrentPosition();

            //ASSERT
            var expectedEndingPosition = new Position(5, 1, CompassPoint.E);
            Assert.AreEqual(expectedEndingPosition.XCoordinate, actualEndingPosition.XCoordinate);
            Assert.AreEqual(expectedEndingPosition.YCoordinate, actualEndingPosition.YCoordinate);
            Assert.AreEqual(expectedEndingPosition.FacingDirection, actualEndingPosition.FacingDirection);
        }

        [Test]
        public void Rover3_FailedMission()
        {
            //ARRANGE
            var plateau = new Plateau(5, 5);
            var startingPosition = new Position(0, 0, CompassPoint.N);
            var rover = new Rover(plateau, startingPosition);
            rover.SubmitMovementPlan("MMMMMM");

            //ACT & ASSERT
            Assert.Throws<RoverCrashedException>(() => rover.ExecuteMovementPlan());
        }
    }
}