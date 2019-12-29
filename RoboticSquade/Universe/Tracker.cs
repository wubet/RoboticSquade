using RoboticSquade.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticSquade.Universe
{
    public class Tracker : ITracker
    {
        private IPosition _currentPosition;
        private IPosition _startingPosition;
        private string _movementPlan;

        public IPosition CurrentPosition
        {
            get { return _currentPosition; }
            set { _currentPosition = value; }
        }
        public IPosition StartingPosition
        {
            get { return _startingPosition; }
            set { _startingPosition = value; }
        }
        public string MovementPlan
        {
            get { return _movementPlan; }
            set { _movementPlan = value; }
        }

        public override string ToString()
        {
            StringBuilder coordinateOutput = new StringBuilder();
            string start = "Starting Position:" + ' ' + _startingPosition.X + ' ' + _startingPosition.Y + ' ' + _startingPosition.Direction;
            coordinateOutput.Append(start);
            coordinateOutput.Append(Environment.NewLine);
            string current = "Current Position:" + ' ' + _currentPosition.X + ' ' + _currentPosition.Y + ' ' + _currentPosition.Direction;
            coordinateOutput.Append(current);
            return coordinateOutput.ToString();
        }



    }
}
