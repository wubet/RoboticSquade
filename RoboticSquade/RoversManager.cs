using RoboticSquade.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticSquade
{
    public class RoversManager : IRoverManager
    {
        IList<IRover> Rovers;
        private ICommandParser _commandParser;
        
        public RoversManager(IList<IRover> rovers, ICommandParser commandParser)
        {
            this.Rovers = rovers;
            this._commandParser = commandParser;
        }

        public void EngineStart()
        {
            foreach(var rover in Rovers)
            {
                string movementPlan = rover.Tracker.MovementPlan;
                char[] movementPlans = movementPlan.ToCharArray();
                foreach(var mov in movementPlans)
                {
                    ICommand command = _commandParser.ParseCommand(mov.ToString().ToUpper());
                    command.Execute(rover);
                }
                Console.WriteLine("Rover Name: " + rover.Name);
                Console.WriteLine(rover.Tracker);
                Console.WriteLine();
            }

        }

    }
}
