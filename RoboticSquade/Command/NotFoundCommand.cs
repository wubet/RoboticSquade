using RoboticSquade.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticSquade.Command
{
    public class NotFoundCommand : ICommand
    {
        public void Execute(IRover rover)
        {
            new EntryPointNotFoundException();
        }
    }
}
