using NASA.Enums;
using NASA.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NASA
{
    public class Rover
    {
        private Plateau _plateau { get; set; }
        private Position _currentPosition { get; set; }
        private List<Move> _movementPlan { get; set; }

        public Rover(Plateau plateau, Position startingPosition)
        {
            _plateau = plateau;
            _currentPosition = startingPosition;
            _movementPlan = new List<Move>();
        }

        public void SubmitMovementPlan(string movementPlan)
        {
            foreach (string moveString in movementPlan.Select(x => x.ToString()).ToList())
            {
                _movementPlan.Add((Move)Enum.Parse(typeof(Move), moveString, true));
            }
        }
                
        public void ExecuteMovementPlan()
        {
            foreach (var move in _movementPlan)
            {
                _currentPosition.UpdatePosition(move);

                //VERIFY ROVER DID NOT FALL OFF THE PLATEAU AFTER LAST MOVE
                if (!_plateau.AreCoordinatedInbound(_currentPosition.XCoordinate, _currentPosition.YCoordinate))
                {
                    throw new RoverCrashedException();
                }
            }           
        }

        public Position GetCurrentPosition()
        {
            return _currentPosition;
        }

    }
}
