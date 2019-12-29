using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticSquade.Interface
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string command);
    }
}
