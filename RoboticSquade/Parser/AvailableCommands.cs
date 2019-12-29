using RoboticSquade.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticSquade.Parser
{
    public class AvailableCommands
    {
        public static Dictionary<string, ICommand> CommandList
        {
            get
            {
                var commands = new Dictionary<string, ICommand>
                {
                    { "M", new MoveForward()},
                    { "L", new RotetLeft()},
                    { "R", new RotetRight()}
                };
                return commands;
            }
        }
    }
}
