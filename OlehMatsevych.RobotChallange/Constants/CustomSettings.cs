namespace OlehMatsevych.RobotChallange.Constants
{
    public class Settings
    {
        public static int MinEnergyForCreateNewRobot { get; private set; } = 325;

        public enum RobotTypeByEnergy
        {
            Master = 1000,
            Strong = 800,
            Miiddle = 700,
            Junior = 200,
        }
        public enum MovingTypes
        {
            Move,
            Create,
            Collect,
        }
    }
}
