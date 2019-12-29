using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticSquade.Interface
{
    public interface IPlateau
    {
        IPosition LowerBound { get; set; }
       
        IPosition UpperBound { get; set; }

        bool isLowerBoundLimitted(int lowerBoundValue, int currentValue);

        bool isUpperBoundLimitted(int upperBoundValue, int currentValue);
        
    }
}
