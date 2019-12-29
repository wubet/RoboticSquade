using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticSquade.Interface
{
    public interface IPosition
    {
        int X { get; set; }
        int Y { get; set; }
        char Direction { get; set; }
    }
}
