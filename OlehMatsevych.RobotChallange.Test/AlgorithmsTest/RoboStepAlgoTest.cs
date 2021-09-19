using Microsoft.VisualStudio.TestTools.UnitTesting;
using OlehMatsevych.RobotChallange.Algorithms;
using Robot.Common;
using System.Collections.Generic;
using Hero = Robot.Common.Robot;

namespace OlehMatsevych.RobotChallange.Test
{
    [TestClass]
    public class RoboStepAlgoTest
    {
        private RoboStepAlgo algo;
        private IList<Hero> Robots { get; set; }
        private int RobotToMoveIndex { get; set; }
        private Map Map { get; set; }


        [TestInitialize]
        public void TestInitialize()
        {
            Robots = new List<Hero>();

            Robots.Add(new Robot.Common.Robot() { Position = new Position() { X = 1, Y = 1 } });
            Robots.Add(new Robot.Common.Robot() { Position = new Position() { X = 3, Y = 8 } });
            Robots.Add(new Robot.Common.Robot() { Position = new Position() { X = 9, Y = 2 } });

            RobotToMoveIndex = 0;
            IList<EnergyStation> stations = new List<EnergyStation>();
            stations.Add(new EnergyStation() { Position = new Position() { X = 2, Y = 2 },Energy = 500 });
            stations.Add(new EnergyStation() { Position = new Position() { X = 4, Y = 7 } });
            Map = new Map()
            {
                Stations = stations
            };

            algo = new RoboStepAlgo(Robots,RobotToMoveIndex,Map);
        }

        [TestMethod]
        public void TestExecute()
        {
            RobotCommand rightRobotCommand = new CollectEnergyCommand();

            RobotCommand robotCommand = algo.Execute();

            Assert.AreEqual(rightRobotCommand.Description, robotCommand.Description);
        }
    }
}
