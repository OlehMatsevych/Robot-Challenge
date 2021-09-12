using System;
using static OlehMatsevych.RobotChallange.Constants.RobotSettings;

namespace OlehMatsevych.RobotChallange.Constants
{
    public class VariantSettings
    {
        public static RobotSettings RobotSetting { get; set; }
        public static StationSettings StationSetting { get; set; }

    }
    public class RobotSettings
    {
        public static int Count { get; private set; } = 10;
        public static int StartEnergy { get; private set; } = 100;
        public static int MaxCellForGettingEnergy  { get; private set; } = 2;
        public static int MaxEnergyGettingPerOneMove { get; private set; } = 40;
        public static int EnergyForReproduction { get; private set; } = 200;
        public static int EnergyToMoveEnemy { get; private set; } = 10;
    

    public class StationSettings
    {
        public static int Count { get; private set; } = 5 * RobotSettings.Count;
        public static int MaxEnergy { get; private set; } = 20000;
        public enum StationsEnergyGenerationPerMove
        {
            MinEnergy = 50,
            MaxEnergy = 100
        };
    }
}
