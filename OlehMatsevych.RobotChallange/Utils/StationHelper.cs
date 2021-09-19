using Robot.Common;
using System.Collections.Generic;
using System;

namespace OlehMatsevych.RobotChallange.Utils
{
    public class StationHelper
    {

        private CellHelper cellHelper { get; set; } = new CellHelper();
        public Position FindNearestFreeStation(Robot.Common.Robot movingRobot, Map map,
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
                        if (station.Position != movingRobot.Position)
                            nearest = station;
                    }
                }
            }

            return nearest == null ? null : nearest.Position;
        }

        public Position FindNearestEnergyPlace(Robot.Common.Robot robot, IList<Position> enablePositions, 
            IList<Robot.Common.Robot> robots)
        { 
            try
            {
                Position nearestEnergyPlace = new Position();
                int minDistance = int.MaxValue;
                foreach (var position in enablePositions)
                {
                    if (position == robot.Position)
                        continue;
                    if (cellHelper.IsCellFree(position, robot, robots))
                    {
                        int d = DistanceHelper.FindDistance(position, robot.Position);
                        if (d < minDistance)
                        {
                            minDistance = d;
                            nearestEnergyPlace = position;
                        }
                    }
                }

                return nearestEnergyPlace == null ? null: nearestEnergyPlace;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsStationFree(EnergyStation station, Robot.Common.Robot movingRobot,
        IList<Robot.Common.Robot> robots)
        {
            return cellHelper.IsCellFree(station.Position, movingRobot, robots);
        }

        public int CountOfStationRobots(IList<Robot.Common.Robot> robots, EnergyStation station)
        {
            int count = 0;
            foreach (Robot.Common.Robot robot in robots)
            {   
                if (IsCollectEnergy(robot.Position, station.Position))
                    count++;
            }
            return count;
        }
        private bool IsCollectEnergy(Position robotPostion, Position stationPosition)
        {
            return ((Math.Abs(robotPostion.X - stationPosition.X) <= 2)
                && (Math.Abs(robotPostion.Y - stationPosition.Y) <= 2));
        }

    }
}
