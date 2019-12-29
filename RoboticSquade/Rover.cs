using RoboticSquade.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RoboticSquade
{
    public class Rover : IRover
    {
        private IPlateau _plato;
        private ITracker _tracker;
        private string _name;

        public IPlateau Plateau
        {
            get { return _plato; }
            set { _plato = value; }
        }

        public ITracker Tracker
        {
            get { return _tracker; }
            set { _tracker = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Rover(string name, IPlateau plato, ITracker tracker)
        {
            this._plato = plato;
            this._name = name;
            this._tracker = tracker;
        }

        /// <summary>
        /// Rotate the navigation direction into 90 degree left
        /// </summary>
        public void SpinLeft()
        {
            bool sucess;
            int changedDirectionValue = -1;
            char changeDirectionName = ' ';

            int currentDirection = GetEnumValue(_tracker.CurrentPosition.Direction, out sucess);
            if (sucess)
            {
                changedDirectionValue = ((currentDirection + 4) - 1) % 4;
                sucess = false;
            }

            changeDirectionName = GetEnumName(changedDirectionValue, out sucess)[0];
            if (sucess)
            {
                _tracker.CurrentPosition.Direction = changeDirectionName;
            }
        }

        ///// <summary>
        ///// Rotate the navigation direction into 90 degree right
        ///// </summary>
        public void SpinRight()
        {
            bool sucess;
            int changedDirectionValue = -1;
            char changeDirectionName = ' ';

            int currentDirection = GetEnumValue(_tracker.CurrentPosition.Direction, out sucess);
            if (sucess)
            {
                changedDirectionValue = (currentDirection + 1) % 4;
                sucess = false;
            }

            changeDirectionName = GetEnumName(changedDirectionValue, out sucess)[0];
            if (sucess)
            {
                _tracker.CurrentPosition.Direction = changeDirectionName;
            }

           }

            /// <summary>
            /// Move the rover into the navigation direction 1 grid
            /// </summary>
            /// <param name="uperBound"></param>
            /// <param name="lowerBound"></param>
            public void MoveForwared()
            {
                if (_tracker.CurrentPosition.Direction == 'N')
                {
                    if(_plato.isUpperBoundLimitted(_plato.UpperBound.Y, _tracker.CurrentPosition.Y))
                    {
                        _tracker.CurrentPosition.Y++;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(_plato.UpperBound.Y.ToString());
                    }
                }
                
                else if (_tracker.CurrentPosition.Direction == 'W')
                {
                    if (_plato.isLowerBoundLimitted(_plato.LowerBound.X, _tracker.CurrentPosition.X))
                    {
                        _tracker.CurrentPosition.X--; 
                    }
                    else 
                    {
                        throw new ArgumentOutOfRangeException(_plato.LowerBound.X.ToString());
                    }
                }
              
                else if (_tracker.CurrentPosition.Direction == 'S')
                {
                    if (_plato.isLowerBoundLimitted(_plato.LowerBound.Y, _tracker.CurrentPosition.Y))
                    {
                        _tracker.CurrentPosition.Y--;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(_plato.LowerBound.Y.ToString());
                    }
                }
                
                else if(_tracker.CurrentPosition.Direction == 'E')
                {
                    if (_plato.isUpperBoundLimitted(_plato.UpperBound.X, _tracker.CurrentPosition.X))
                    {
                        _tracker.CurrentPosition.X++;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(_plato.UpperBound.X.ToString());
                    }
                }
        }

        /// <summary>
        /// Returns the numberic value of the Navigation direction
        /// </summary>
        /// <param name="dirName">navigation direction</param>
        /// <param name="success">determine success or failer</param>
        /// <returns></returns>
        private static int GetEnumValue(char dirName, out bool success)
        {
            success = false;
            Array enumValueArray = Enum.GetValues(typeof(Directions));
            foreach (int enumValue in enumValueArray)
            {
                var name = Enum.GetName(typeof(Directions), enumValue);
                if (name == dirName.ToString())
                {
                    success = true;
                    return enumValue;
                }
                
            }
            return -1;
        }

        /// <summary>
        /// Returns the Navigation direction based on its enum value
        /// </summary>
        /// <param name="value">enum value</param>
        /// <param name="success"> determine success or failer</param>
        /// <returns></returns>
        private static char[] GetEnumName(int value, out bool success)
        {
            success = false;
            string name = null;
            Array enumValueArray = Enum.GetValues(typeof(Directions));

            foreach (int enumValue in enumValueArray)
            {

                if (value == enumValue)
                {
                    name = Enum.GetName(typeof(Directions), enumValue);
                    success = true;
                  
                }

            }
            return name.ToCharArray();
        }

    }

}
