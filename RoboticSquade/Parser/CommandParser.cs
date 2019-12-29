using RoboticSquade.Command;
using RoboticSquade.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticSquade.Parser
{
    public class CommandParser : ICommandParser
    {
        private Dictionary<string, ICommand> _commands;

        public CommandParser(Dictionary<string, ICommand> commands)
        {
            _commands = commands;
        }

        public ICommand ParseCommand(string command)
        {
            if (_commands.ContainsKey(command))
                return _commands[command];
            return new NotFoundCommand();
        }
    }
}
