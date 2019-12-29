using RoboticSquade.Interface;
using RoboticSquade.Parser;
using RoboticSquade.Universe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticSquade
{
    class Program
    {
        static void Main(string[] args)
        {
            IPosition upperLimit = new Position { X = 5, Y = 5 };
            IPosition lowerLimit = new Position { X = 0, Y = 0 };
            IPlateau plato = new Plateau(lowerLimit, upperLimit);
            Dictionary<string, ICommand> _availableCommands = AvailableCommands.CommandList;

            Console.WriteLine("How Many Robotic Rovers you would linke to land on Plateau: use only Numberic value");
            String roverSizeImput = Console.ReadLine();
            int roverSize;
            Int32.TryParse(roverSizeImput, out roverSize);
            Rover[] rovers = new Rover[roverSize];

            for (int i = 0; i < roverSize; i++)
            {
                Console.WriteLine("Enter {0} 'X' cordinate starting postion between 0 to 5", "Rover " + (i + 1));
                String X = Console.ReadLine();
                int xValue;
                Int32.TryParse(X, out xValue);

                Console.WriteLine("Enter {0} 'Y' cordinate starting postion between 0 to 5", "Rover " + (i + 1));
                String Y = Console.ReadLine();
                int yValue;
                Int32.TryParse(Y, out yValue);

                Console.WriteLine("Enter {0} starting navigation direction. input 'N', 'E', 'S', 'W'", "Rover " + (i + 1));
                String dir = Console.ReadLine();
                char dirValue = dir.ToCharArray()[0];

                IPosition start = new Position()
                {
                    X = xValue,
                    Y = yValue,
                    Direction = dirValue
                };

                Position current = new Position()
                {
                    X = xValue,
                    Y = yValue,
                    Direction = dirValue
                };

                ITracker tracker = new Tracker();

                Rover rover = new Rover("Rover " + (i + 1), plato, tracker);

                rover.Tracker.StartingPosition = start;
                rover.Tracker.CurrentPosition = current;

                Console.WriteLine("Enter {0} Movement Plan. input acombination of the following letters 'L', 'R', 'S'", "Rover " + (i + 1));
                String movment = Console.ReadLine();
                rover.Tracker.MovementPlan = movment;

                rovers[i] = rover;

            }



            //Rover[] rovers =
            //{
            //    new Rover("Rover 1", plato, new Tracker()
            //    {
            //         StartingPosition = new Position()
            //        {
            //            X = 1, Y = 2, Direction = 'N'
            //        },
            //        CurrentPosition = new Position()
            //        {
            //            X = 1, Y = 2, Direction = 'N'
            //        },
            //        MovementPlan = "LMLMLMLMM"
            //    }),
            //    new Rover("Rover 2", plato, new Tracker()
            //    {
            //        StartingPosition = new Position()
            //        {
            //            X = 3, Y = 3, Direction = 'E'
            //        },
            //        CurrentPosition = new Position()
            //        {
            //            X = 3, Y = 3, Direction = 'E'
            //        },
            //        MovementPlan = "MMRMMRMRRM"

            //    })
            //};

            ICommandParser parser = new CommandParser(_availableCommands);
            Init(rovers, parser);
            Console.ReadLine();

        }

        private static void Init(IList<IRover> rovers, ICommandParser parser)
        {
            RoversManager mgr = new RoversManager(rovers, parser);
            mgr.EngineStart();

        }


    }
}
