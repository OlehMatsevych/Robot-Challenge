using OlehMatsevych.RobotChallange.Constants;
using Robot.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OlehMatsevych.RobotChallange.Constants.Settings;
using Hero = Robot.Common.Robot;

namespace OlehMatsevych.RobotChallange.Algorithms
{
    public class EnableEnergyDistance
    {
        public MovingTypes IsEnable(Position stationPosition, Hero robot )
        {
            for (int i = 0; i < RobotSettings.MaxCellForGettingEnergy; i++)
            {
                for (int j = 0; j < RobotSettings.MaxCellForGettingEnergy; j++)
                {
                    if (IsNotOutOfStation(stationPosition,robot,i,j))
                    {
                        return MovingTypes.Collect;
                    }
                }
            }
            return MovingTypes.Move;
        }

        private bool IsNotOutOfStation(Position stationPosition, Hero robot, int i, int j)
        {
            return stationPosition.X + i == robot.Position.X || stationPosition.Y + j == robot.Position.Y ||
                        stationPosition.X - i == robot.Position.X || stationPosition.Y - j == robot.Position.Y;
        }
    }
}
