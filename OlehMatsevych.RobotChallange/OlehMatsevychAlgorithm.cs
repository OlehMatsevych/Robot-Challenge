using OlehMatsevych.RobotChallange.Algorithms;
using Robot.Common;
using System;
using System.Collections.Generic;

namespace OlehMatsevych.RobotChallange
{
    public class OlehMatsevychAlgorithm : IRobotAlgorithm
    {
        public string Author { get { return "Oleh Matsevych"; } }
        public int Round { get; set; }

        public OlehMatsevychAlgorithm()
        {
            Logger.OnLogRound += OnLogRoundLogger;
        }
        private void OnLogRoundLogger(object sender, LogRoundEventArgs e)
        {
            Round++;
        }
        public RobotCommand DoStep(IList<Robot.Common.Robot> robots, int robotToMoveIndex, Map map)
        {
            try
            {
                var step = new RoboStepAlgo(robots, robotToMoveIndex ,map, Round);
                return step.Execute();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
