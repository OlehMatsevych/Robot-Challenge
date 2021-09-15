using OlehMatsevych.RobotChallange.Algorithms;
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
            var step = new RoboStepAlgo(robots, robotToMoveIndex ,map);
            return step.Execute();
        }
    }
}
