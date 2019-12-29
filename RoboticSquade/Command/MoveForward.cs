using RoboticSquade.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticSquade
{
    public class MoveForward : ICommand
    {
        public void Execute(IRover rover)
        {
            rover.MoveForwared();
        }
    }
}
