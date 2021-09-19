using Microsoft.VisualStudio.TestTools.UnitTesting;
using OlehMatsevych.RobotChallange.Utils;
using Robot.Common;
using System.Collections.Generic;

namespace OlehMatsevych.RobotChallange.Test.UtilsTest
{
    [TestClass]
    public class StationHelperTest
    {
        private StationHelper stationHelper;

        [TestInitialize]
        public void TestInitialize()
        {
            stationHelper = new StationHelper();
        }

        [TestMethod]
        public void TestFindNearestFreeStation()
        {
            Robot.Common.Robot movingRobot = new Robot.Common.Robot()
            {
                Position = new Position() { X = 1, Y = 1 }
            };
            IList<Robot.Common.Robot> robots = new List<Robot.Common.Robot>();
            robots.Add(new Robot.Common.Robot() { Position = new Position() { X = 1, Y = 1 } });
            robots.Add(new Robot.Common.Robot() { Position = new Position() { X = 3, Y = 8 } });
            robots.Add(new Robot.Common.Robot() { Position = new Position() { X = 9, Y = 2 } });

            IList<EnergyStation> stations = new List<EnergyStation>();
            stations.Add(new EnergyStation() { Position = new Position() { X = 3, Y = 2 } });
            stations.Add(new EnergyStation() { Position = new Position() { X = 2, Y = 5 } });
            var Map = new Map()
            {
                Stations = stations
            };
            var position = stationHelper.FindNearestFreeStation(movingRobot, Map, robots);

            EnergyStation nearest = new EnergyStation() {
                Position = new Position() { X = 3, Y = 2 } 
            };

            Assert.AreEqual(nearest.Position, position);
        }

        [TestMethod]
        public void TestFindNearestEnergyPlace()
        {
            Robot.Common.Robot movingRobot = new Robot.Common.Robot()
            {
                Position = new Position() { X = 1, Y = 1 }
            };
            IList<Robot.Common.Robot> robots = new List<Robot.Common.Robot>();
            robots.Add(new Robot.Common.Robot() { Position = new Position() { X = 1, Y = 1 } });
            robots.Add(new Robot.Common.Robot() { Position = new Position() { X = 3, Y = 8 } });
            robots.Add(new Robot.Common.Robot() { Position = new Position() { X = 9, Y = 2 } });

            IList<Position> enablePositions = new List<Position>();
            enablePositions.Add(new Position() { X = 3, Y = 2 });
            enablePositions.Add(new Position() { X = 2, Y = 5 });

            var position = stationHelper.FindNearestEnergyPlace(movingRobot, enablePositions, robots);

            EnergyStation nearest = new EnergyStation()
            {
                Position = new Position() { X = 3, Y = 2 }
            };

            Assert.AreEqual(nearest.Position, position);
        }

        [TestMethod]
        public void TestIsStationFree()
        {
            Robot.Common.Robot movingRobot = new Robot.Common.Robot()
            {
                Position = new Position() { X = 1, Y = 3 }
            };
            IList<Robot.Common.Robot> robots = new List<Robot.Common.Robot>();
            robots.Add(new Robot.Common.Robot() { Position = new Position() { X = 12, Y = 23 } });
            robots.Add(new Robot.Common.Robot() { Position = new Position() { X = 33, Y = 23 } });
            robots.Add(new Robot.Common.Robot() { Position = new Position() { X = 44, Y = 25 } });

            EnergyStation station = new EnergyStation()
            {
                Position = new Position() { X = 3, Y = 2 }
            };
            bool isStationFree = stationHelper.IsStationFree(station, movingRobot, robots);

            Assert.IsTrue(isStationFree);
        }

        [TestMethod]
        public void TestCountOfStationRobots()
        {
            IList<Robot.Common.Robot> robots = new List<Robot.Common.Robot>();
            robots.Add(new Robot.Common.Robot() { Position = new Position() { X = 12, Y = 23 } });
            robots.Add(new Robot.Common.Robot() { Position = new Position() { X = 33, Y = 23 } });
            robots.Add(new Robot.Common.Robot() { Position = new Position() { X = 44, Y = 25 } });

            EnergyStation station = new EnergyStation()
            {
                Position = new Position() { X = 32, Y = 22 }
            };

            int count = stationHelper.CountOfStationRobots(robots, station);
            Assert.AreEqual(count, 1);

        }
    }
}
