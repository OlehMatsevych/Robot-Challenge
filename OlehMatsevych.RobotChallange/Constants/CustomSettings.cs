using System;
using System.Collections.Generic;

namespace OlehMatsevych.RobotChallange.Constants
{
    public class Settings
    {
        public static int MinEnergyForCreateNewRobot { get; private set; } = 200;

        public enum RobotTypeByEnergy
        {
            Master = 1000,
            Strong = 750,
            Miiddle = 500,
            Junior = 100,
        }
        public enum MovingTypes
        {
            Move,
            Create,
            Collect,
        }
    }
}
