using Robot.Common;
using System.Collections.Generic;

namespace OlehMatsevych.RobotChallange.Utils
{
    public class StationHelper
    {
        public static Position FindNearestFreeStation(Robot.Common.Robot movingRobot, Map map,
            IList<Robot.Common.Robot> robots)
        {
            EnergyStation nearest = null;
            int minDistance = int.MaxValue;
            foreach (var station in map.Stations)
            {
                if (IsStationFree(station, movingRobot, robots))
                {
                    int d = DistanceHelper.FindDistance(station.Position, movingRobot.Position);
                    if (d < minDistance)

                    {
                        minDistance = d;
                        nearest = station;
                    }
                }
            }
            return nearest == null ? null : nearest.Position;
        }
        public static bool IsStationFree(EnergyStation station, Robot.Common.Robot movingRobot,
        IList<Robot.Common.Robot> robots)
        {
            return CellHelper.IsCellFree(station.Position, movingRobot, robots);
        }
    }
}
