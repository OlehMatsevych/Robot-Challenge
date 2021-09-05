using Robot.Common;
using System;

namespace OlehMatsevych.RobotChallange.Utils
{
    public class DistanceHelper
    {
        public static int FindDistance(Position a, Position b) =>
            (int)(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
    }
}
