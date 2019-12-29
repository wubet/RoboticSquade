using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticSquade.Interface
{
    public interface ITracker
    {
        IPosition CurrentPosition { get; set; }
        IPosition StartingPosition { get; set; }
        string MovementPlan { get; set; }

    }
}
