using Robot.Common;
using System.Collections.Generic;

namespace OlehMatsevych.RobotChallange.Utils
{
    public class CellHelper
    {
        public static bool IsCellFree(Position cell, Robot.Common.Robot movingRobot, IList<Robot.Common.Robot> robots)
        {
            foreach (var robot in robots)
            {
                if (robot != movingRobot)
                {
                    if (robot.Position == cell)
                        return false;
                }
            }
            return true;
        }
    }
}
