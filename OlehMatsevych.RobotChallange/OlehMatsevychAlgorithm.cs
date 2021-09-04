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

            var newPosition = robot.Position;
            newPosition.X += 2;
            newPosition.Y += 2;
            return new MoveCommand() { NewPosition = newPosition };

        }
    }
}
