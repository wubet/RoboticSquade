using RoboticSquade.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticSquade
{
    public class Plateau : IPlateau
    {
        private IPosition _lowerBound;
        private IPosition _upperBound;

        public IPosition LowerBound
        {
            get { return this._lowerBound; }
            set { value = _lowerBound; }
        }
        public IPosition UpperBound
        {
            get { return this._upperBound; }
            set { value = _upperBound; }

        }

        public Plateau(IPosition lowerLimit, IPosition upperLimit)
        {
            this._lowerBound = lowerLimit;
            this._upperBound = upperLimit;
        }

        //public void setLowerLimit()
        //{
        //    this.lowerLimit = new Position { X = 0, Y = 0 };
        //}

        //public void setUperLimit()
        //{
        //    this.upperLimit = new Position { X = 5, Y = 5 };
        //}
        public bool isLowerBoundLimitted(int lowerBoundValue, int currentValue)
        {
            return (currentValue - 1) >= lowerBoundValue;
        }

        public bool isUpperBoundLimitted(int upperBoundValue, int currentValue)
        {
            return (currentValue + 1) <= upperBoundValue;
        }

    }
}
