using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Robot.Common;
using Hero  = Robot.Common.Robot;
using static OlehMatsevych.RobotChallange.Constants.Settings;
using OlehMatsevych.RobotChallange.Constants;
using OlehMatsevych.RobotChallange.Utils;

namespace OlehMatsevych.RobotChallange.Algorithms
{
    public class RoboStepAlgo
    {
        private IList<Hero> Robots { get; set; }
        private int RobotToMoveIndex { get; set; }
        private Map Map { get; set; }
        private Hero Robot { get; set; }
        private Position Position { get; set; }
        private RobotTypeByEnergy RobotType { get; set; }
        private MovingTypes MovingType { get; set; }
        private delegate void Executer();
        private delegate void PriorityAlgorithn();

        public RoboStepAlgo() { }
        public RoboStepAlgo(IList<Hero> robots, int robotToMoveIndex, Map map)
        {
            Robots = robots;
            RobotToMoveIndex = robotToMoveIndex;
            Map = map;
            Robot = Robots[RobotToMoveIndex];
        }

        public RobotCommand Execute()
        {
            Executer executer = SetRobotType;
            executer += SetAlgorithm;
            executer();

            if (MovingType == MovingTypes.Move)
            {
                return new MoveCommand() { NewPosition = Position };
            }
            else if (MovingType == MovingTypes.Collect)
            {
                return new CollectEnergyCommand();
            }
            else if (MovingType == MovingTypes.Create)
            {
                return new CreateNewRobotCommand();
            }
            return null;
        }
        private void SetRobotType()
        {
            RobotType = RobotTypeByEnergy.Junior;
        }
        private void SetAlgorithm()
        {
            PriorityAlgorithn algo;
            if (RobotType == RobotTypeByEnergy.Junior)
            {
                algo = JuniorAlgo;
                algo();
            }
        }
        private void JuniorAlgo()
        {
            if ((Robot.Energy >= MinEnergyForCreateNewRobot) && (Robots.Count < Map.Stations.Count))
            {
                MovingType = MovingTypes.Create;
                return;
            }
            StationHelper stationHelper = new StationHelper();

            Position stationPosition = stationHelper.FindNearestFreeStation(Robot, Map, Robots);
            EnergyStation station = Map.Stations.Where(t => t.Position.X== stationPosition.X && t.Position.Y == stationPosition.Y).First();

            if (station.Energy > 40 && stationHelper.CountOfStationRobots(Robots, station) <= 2)
            {
                EnableEnergyDistance enableEnergy = new EnableEnergyDistance();
                MovingType = enableEnergy.CheckForCollectType(stationPosition, Robot);
            }
            else
            {
                MovingType = MovingTypes.Move;
            }
            /*
                1 2 
                3 4
            */
            if (MovingType == MovingTypes.Move && stationPosition != null)
            {
                if(station.Position == Robot.Position)
                {
                    Map.Stations.Remove(station);
                    stationPosition = stationHelper.FindNearestFreeStation(Robot, Map, Robots);
                }
                List<Position> enableStationPositions = new List<Position>();
                if(stationPosition.X >= Robot.Position.X && stationPosition.Y >= Robot.Position.Y)    //3
                {
                    //(-inf;-inf)
                    for (int i = stationPosition.X; i <= stationPosition.X + 2; i++) 
                    {
                        for (int j= stationPosition.Y; j <= stationPosition.Y + 2 ; j++)
                        {
                            enableStationPositions.Add(new Position()
                            {
                                X = i,
                                Y = j
                            });
                        }
                    }
                    Position newPosition = stationHelper.FindNearestEnergyPlace(Robot, enableStationPositions, Robots);
                    while (Robot.Energy < DistanceHelper.FindDistance(Robot.Position, newPosition))
                    {
                        if (enableStationPositions.Count == 0)
                            break;
                        enableStationPositions.Remove(newPosition);
                        newPosition = stationHelper.FindNearestEnergyPlace(Robot, enableStationPositions, Robots);

                    }
                    Position = newPosition;
                }
                else if (stationPosition.X >= Robot.Position.X && stationPosition.Y <= Robot.Position.Y)   //1
                {
                    //(-inf;+inf)
                    for (int i = stationPosition.X; i <= stationPosition.X + 2; i++)
                    {
                        for (int j = stationPosition.Y; j >= stationPosition.Y-2; j--)
                        {
                            enableStationPositions.Add(new Position()
                            {
                                X = i,
                                Y = j
                            });
                        }
                    }
                    Position newPosition = stationHelper.FindNearestEnergyPlace(Robot, enableStationPositions, Robots);
                    while (Robot.Energy < DistanceHelper.FindDistance(Robot.Position, newPosition))
                    {
                        if (enableStationPositions.Count == 0)
                            break;
                        enableStationPositions.Remove(newPosition);
                        newPosition = stationHelper.FindNearestEnergyPlace(Robot, enableStationPositions, Robots);
                        
                    }
                    Position = newPosition;
                }
                else if (stationPosition.X <= Robot.Position.X && stationPosition.Y >= Robot.Position.Y)   //4
                {
                    //(+inf;-inf)
                    for (int i = stationPosition.X; i >= stationPosition.X-2; i--)
                    {
                        for (int j = stationPosition.Y; j <= stationPosition.Y+2; j++)
                        {
                            enableStationPositions.Add(new Position()
                            {
                                X = i,
                                Y = j
                            });
                        }
                    }
                    Position newPosition = stationHelper.FindNearestEnergyPlace(Robot, enableStationPositions, Robots);
                    while (Robot.Energy < DistanceHelper.FindDistance(Robot.Position, newPosition))
                    {
                        if (enableStationPositions.Count == 0)
                            break;
                        enableStationPositions.Remove(newPosition);
                        newPosition = stationHelper.FindNearestEnergyPlace(Robot, enableStationPositions, Robots); 
                       
                    }
                    Position = newPosition;
                }
                else if (stationPosition.X <= Robot.Position.X && stationPosition.Y <= Robot.Position.Y)   //2
                {
                    //(+inf;+inf)
                    for (int i = stationPosition.X; i >= stationPosition.X-2; i--)
                    {
                        for (int j = stationPosition.Y; j >= stationPosition.Y-2; j--)
                        {
                            enableStationPositions.Add(new Position()
                            {
                                X = i,
                                Y = j
                            });
                        }
                    }
                    Position newPosition = stationHelper.FindNearestEnergyPlace(Robot, enableStationPositions, Robots);
                    while (Robot.Energy < DistanceHelper.FindDistance(Robot.Position, newPosition))
                    {
                        if (enableStationPositions.Count == 0)
                            break;
                        enableStationPositions.Remove(newPosition);
                        newPosition = stationHelper.FindNearestEnergyPlace(Robot, enableStationPositions, Robots);
                        
                    }
                    Position = newPosition;
                }
            }

        }
    }
}
