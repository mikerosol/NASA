using NASA.Enums;
using NASA.Exceptions;
using System;
using System.Linq;

namespace NASA
{
    class Program
    {
        static void Main(string[] args)
        {
            var plateau = GetPlateau();

            while (true)
            {
                Position startingPosition = GetRoverStartingPosition();
                string movementPlan = GetRoverMovementPlan();
                Position finalPositon = null;
                var rover = new Rover(plateau, startingPosition);
                rover.SubmitMovementPlan(movementPlan);

                try
                {
                    rover.ExecuteMovementPlan();
                    finalPositon = rover.GetCurrentPosition();
                    Console.WriteLine("MISSION SUCCESSFUL");
                    Console.WriteLine($"X:{finalPositon.XCoordinate} Y:{finalPositon.YCoordinate} Facing Direction:{finalPositon.FacingDirection}\n");

                }

                catch (RoverCrashedException)
                {
                    finalPositon = rover.GetCurrentPosition();
                    Console.WriteLine("MISSION FAILED! - Rover fell of plateau");
                    Console.WriteLine($"Crash location: X:{finalPositon.XCoordinate} Y:{finalPositon.YCoordinate} Facing Direction:{finalPositon.FacingDirection}\n");
                } 
            }
        }

        private static Plateau GetPlateau()
        {
            Console.Write("Enter Graph Upper Right Coordinate: ");

            var input = Console.ReadLine()
                .Trim()
                .Split(' ')
                .Select(Int32.Parse)
                .ToList();

            Console.WriteLine();

            return new Plateau(input[0], input[1]);
        }
        private static Position GetRoverStartingPosition()
        {
            Console.Write("Starting Position: ");

            var input = Console.ReadLine()
                .Trim()
                .Split(' ')
                .ToList();

            var x = Convert.ToInt32(input[0]);
            var y = Convert.ToInt32(input[1]);
            var facingDirection = (CompassPoint)Enum.Parse(typeof(CompassPoint), input[2], true);

            return new Position(x, y, facingDirection);
        }
        private static string GetRoverMovementPlan()
        {
            Console.Write("Movement Plan: ");

            return Console.ReadLine().Trim();
        }
    }
}
