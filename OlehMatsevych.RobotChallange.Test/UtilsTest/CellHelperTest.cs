using Microsoft.VisualStudio.TestTools.UnitTesting;
using OlehMatsevych.RobotChallange.Utils;
using Robot.Common;
using System;
using System.Collections.Generic;

namespace OlehMatsevych.RobotChallange.Test
{
    [TestClass]
    public class CellHelperTest
    {
        [TestMethod]
        public void TestIsCellFree()
        {
            CellHelper cellHelper = new CellHelper();

            Position cell = new Position() { X = 3, Y = 4 };
            Robot.Common.Robot movingRobot = new Robot.Common.Robot()
            {
                Position = new Position() { X = 1, Y = 3 }
            };
            IList<Robot.Common.Robot> robots = new List<Robot.Common.Robot>();
            robots.Add(new Robot.Common.Robot() { Position = new Position() { X = 1, Y = 3 } });
            robots.Add(new Robot.Common.Robot() { Position = new Position() { X = 3, Y = 2 } });
            robots.Add(new Robot.Common.Robot() { Position = new Position() { X = 4, Y = 2 } });

            bool freeCell = cellHelper.IsCellFree(cell, movingRobot, robots);
            Assert.IsTrue(freeCell);
        }
    }
}
