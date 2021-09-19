using Microsoft.VisualStudio.TestTools.UnitTesting;
using OlehMatsevych.RobotChallange.Utils;
using Robot.Common;
using System;

namespace OlehMatsevych.RobotChallange.Test
{
    [TestClass]
    public class DistanceHelperTest
    {
        [TestMethod]
        public void TestFindDistance()
        {
            var a = new Position(12, 12);
            var b = new Position(13, 15);

            int distance = DistanceHelper.FindDistance(a,b);
            Assert.AreEqual(10, distance);
        }
    }
}
