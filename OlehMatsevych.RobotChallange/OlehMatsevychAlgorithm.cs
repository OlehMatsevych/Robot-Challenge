using OlehMatsevych.RobotChallange.Constants;
using OlehMatsevych.RobotChallange.Utils;
using Robot.Common;
using System;
using System.Collections.Generic;

namespace OlehMatsevych.RobotChallange
{
    public class OlehMatsevychAlgorithm : IRobotAlgorithm
    {
        public string Author { get { return "Oleh Matsevych"; } }

        public RobotCommand DoStep(IList<Robot.Common.Robot> robots, int robotToMoveIndex, Map map)
        {
            var robot = robots[robotToMoveIndex];

            if ((robot.Energy > Settings.MinEnergyForCreateNewRobot) && (robots.Count < map.Stations.Count))
            {
                return new CreateNewRobotCommand();
            }

            Position stationPosition = StationHelper.FindNearestFreeStation(robots[robotToMoveIndex], map, robots);
            if (stationPosition == null) 
                return null;
            if (stationPosition == robot.Position)
                return new CollectEnergyCommand();
            else
            {
                return new MoveCommand() { NewPosition = stationPosition };
            }

        }
    }
}
