using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticSquade.Interface
{
    public interface IRover
    {
        ITracker Tracker { get; set; }
        IPlateau Plateau { get; set;  }
        string Name { get; set; }
        void SpinLeft();
        void SpinRight();
        void MoveForwared();


    }
}
