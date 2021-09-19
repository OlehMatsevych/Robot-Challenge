using Microsoft.VisualStudio.TestTools.UnitTesting;
using OlehMatsevych.RobotChallange.Algorithms;
using Robot.Common;
using System;
using static OlehMatsevych.RobotChallange.Constants.Settings;

namespace OlehMatsevych.RobotChallange.Test.AlgorithmsTest
{
    [TestClass]
    public class EnableEnergyDistanceTest
    {
        [TestMethod]
        public void TestCheckForCollectType()
        {
            EnableEnergyDistance enableEnergyDistance = new EnableEnergyDistance();

            Position stationPosition = new Position()
            {
                X = 5,
                Y = 3
            };
            Robot.Common.Robot movingRobot = new Robot.Common.Robot()
            {
                Position = new Position() { X = 6, Y = 1 }
            };


            MovingTypes rightType = MovingTypes.Collect;
            MovingTypes type = enableEnergyDistance.CheckForCollectType(stationPosition, movingRobot);

            Assert.AreEqual(rightType,type);

        }
    }
}
