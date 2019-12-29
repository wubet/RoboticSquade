using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoboticSquade;
using RoboticSquade.Interface;
using RoboticSquade.Universe;

namespace RoboticSquadeTest
{
    [TestClass]
    public class RoverPositionTest
    {
        static IPosition upperLimit = new Position { X = 5, Y = 5 };
        static IPosition lowerLimit = new Position { X = 0, Y = 0 };
        IPlateau plato = new Plateau(lowerLimit, upperLimit);

        [TestMethod]
        public void ValidateRoverSpiningLeft()
        {
            Rover rover = new Rover("Rover 1", plato, new Tracker()
            {
                StartingPosition = new Position()
                {
                    X = 1,
                    Y = 2,
                    Direction = 'N'
                },
                CurrentPosition = new Position()
                {
                    X = 1,
                    Y = 2,
                    Direction = 'N'
                },
                MovementPlan = "LMLMLMLMM"

            });
           

            rover.SpinLeft();

            Assert.AreEqual('W', rover.Tracker.CurrentPosition.Direction);

        }


        [TestMethod]
        public void ValidateRoverSpiningRight()
        {
            Rover rover = new Rover("Rover 2", plato, new Tracker()
            {
                StartingPosition = new Position()
                {
                    X = 3,
                    Y = 3,
                    Direction = 'E'
                },
                CurrentPosition = new Position()
                {
                    X = 3,
                    Y = 3,
                    Direction = 'E'
                },
                MovementPlan = "MMRMMRMRRM"

            });
            rover.SpinRight();

            Assert.AreEqual('S', rover.Tracker.CurrentPosition.Direction);

        }


        //[TestMethod]
        //public void ValidateRoverCurrentPosition()
        //{


        //    RoboticRovers[] rovers =
        //    {
        //        new RoboticRovers("Rover 1")
        //        {
        //            StartingPosition = new Position()
        //            {
        //                X = 1, Y = 2, Direction = 'N'
        //            },
        //            CurrentPosition = new Position()
        //            {
        //                X = 1, Y = 2, Direction = 'N'
        //            },
        //            MovementPlan = "LMLMLMLMM"
        //        },
        //    };

        //    RoversManager mgr = new RoversManager(rovers, upperLimit, lowerLimit);

        //    mgr.StartMoving();

        //}
    }
}



