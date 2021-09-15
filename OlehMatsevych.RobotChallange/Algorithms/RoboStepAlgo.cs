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
            if(Robot.Energy > (int)RobotTypeByEnergy.Master)
            {
                RobotType = RobotTypeByEnergy.Master;
            }
            else if (Robot.Energy > (int)RobotTypeByEnergy.Strong && Robot.Energy < (int)RobotTypeByEnergy.Master)
            {
                RobotType = RobotTypeByEnergy.Strong;
            }
            else if (Robot.Energy > (int)RobotTypeByEnergy.Miiddle && Robot.Energy < (int)RobotTypeByEnergy.Strong)
            {
                RobotType = RobotTypeByEnergy.Miiddle;
            }
            else
            {
                RobotType = RobotTypeByEnergy.Junior;
            }
        }
        private void SetAlgorithm()
        {
            PriorityAlgorithn algo;
            if (RobotType == RobotTypeByEnergy.Master)
            {
                algo = MasterAlgo;
                algo();

            }
            else if (RobotType == RobotTypeByEnergy.Strong)
            {
                algo = StrongAlgo;
                algo();
            }
            else if (RobotType == RobotTypeByEnergy.Miiddle)
            {
                algo = MiddleAlgo;
                algo();
            }
            else if (RobotType == RobotTypeByEnergy.Junior)
            {
                algo = JuniorAlgo;
                algo();
            }
        }

        private void MasterAlgo()
        {
            if ((Robot.Energy >= MinEnergyForCreateNewRobot) && (Robots.Count < Map.Stations.Count))
            {
                MovingType = MovingTypes.Create;
                return;
            }
            StationHelper stationHelper = new StationHelper();
            Position stationPosition = stationHelper.FindNearestFreeStation(Robot, Map, Robots);

            EnableEnergyDistance enableEnergy = new EnableEnergyDistance();
            MovingType = enableEnergy.IsEnable(stationPosition, Robot);
            if (MovingType == MovingTypes.Move)
            {
                for (int i = 0; i < RobotSettings.MaxCellForGettingEnergy; i++)
                {
                    for (int j = 0; j < RobotSettings.MaxCellForGettingEnergy; j++)
                    {
                        if (stationPosition.X + i == Robot.Position.X || stationPosition.Y + j == Robot.Position.Y)
                        {
                            Position = new Position(stationPosition.X + i, stationPosition.Y + j);
                        }
                        if (stationPosition.X - i == Robot.Position.X || stationPosition.Y - j == Robot.Position.Y)
                        {
                            Position = new Position(stationPosition.X - i, stationPosition.Y-j);
                        }
                        if (stationPosition.X - i == Robot.Position.X || stationPosition.Y + j == Robot.Position.Y)
                        {
                            Position = new Position(stationPosition.X - i, stationPosition.Y + j);
                        }
                        if (stationPosition.X + i == Robot.Position.X || stationPosition.Y - j == Robot.Position.Y)
                        {
                            Position = new Position(stationPosition.X + i, stationPosition.Y - j);
                        }
                    }
                }
            }
        }
        private void StrongAlgo()
        {
            if ((Robot.Energy >= MinEnergyForCreateNewRobot) && (Robots.Count < Map.Stations.Count))
            {
                MovingType = MovingTypes.Create;
                return;
            }
            StationHelper stationHelper = new StationHelper();
            Position stationPosition = stationHelper.FindNearestFreeStation(Robot, Map, Robots);
            EnableEnergyDistance enableEnergy = new EnableEnergyDistance();
            MovingType = enableEnergy.IsEnable(stationPosition, Robot);
            if (MovingType == MovingTypes.Move)
            {
                for (int i = 0; i < RobotSettings.MaxCellForGettingEnergy; i++)
                {
                    for (int j = 0; j < RobotSettings.MaxCellForGettingEnergy; j++)
                    {
                        if (stationPosition.X + i == Robot.Position.X || stationPosition.Y + j == Robot.Position.Y)
                        {
                            Position = new Position(stationPosition.X + i, stationPosition.Y + j);
                        }
                        if (stationPosition.X - i == Robot.Position.X || stationPosition.Y - j == Robot.Position.Y)
                        {
                            Position = new Position(stationPosition.X - i, stationPosition.Y - j);
                        }
                        if (stationPosition.X - i == Robot.Position.X || stationPosition.Y + j == Robot.Position.Y)
                        {
                            Position = new Position(stationPosition.X - i, stationPosition.Y + j);
                        }
                        if (stationPosition.X + i == Robot.Position.X || stationPosition.Y - j == Robot.Position.Y)
                        {
                            Position = new Position(stationPosition.X + i, stationPosition.Y - j);
                        }
                    }
                }
            }
        }
        private void MiddleAlgo()
        {
            if ((Robot.Energy >= MinEnergyForCreateNewRobot) && (Robots.Count < Map.Stations.Count))
            {
                MovingType = MovingTypes.Create;
                return;
            }
            StationHelper stationHelper = new StationHelper();
            Position stationPosition = stationHelper.FindNearestFreeStation(Robot, Map, Robots);
            EnableEnergyDistance enableEnergy = new EnableEnergyDistance();
            MovingType = enableEnergy.IsEnable(stationPosition, Robot);
            if (MovingType == MovingTypes.Move)
            {
                for (int i = 0; i < RobotSettings.MaxCellForGettingEnergy; i++)
                {
                    for (int j = 0; j < RobotSettings.MaxCellForGettingEnergy; j++)
                    {
                        if (stationPosition.X + i == Robot.Position.X || stationPosition.Y + j == Robot.Position.Y)
                        {
                            Position = new Position(stationPosition.X + i, stationPosition.Y + j);
                        }
                        if (stationPosition.X - i == Robot.Position.X || stationPosition.Y - j == Robot.Position.Y)
                        {
                            Position = new Position(stationPosition.X - i, stationPosition.Y - j);
                        }
                        if (stationPosition.X - i == Robot.Position.X || stationPosition.Y + j == Robot.Position.Y)
                        {
                            Position = new Position(stationPosition.X - i, stationPosition.Y + j);
                        }
                        if (stationPosition.X + i == Robot.Position.X || stationPosition.Y - j == Robot.Position.Y)
                        {
                            Position = new Position(stationPosition.X + i, stationPosition.Y - j);
                        }
                    }
                }
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
            EnableEnergyDistance enableEnergy = new EnableEnergyDistance();
            MovingType = enableEnergy.IsEnable(stationPosition, Robot);
            if (MovingType == MovingTypes.Move)
            {
                for (int i = 0; i < RobotSettings.MaxCellForGettingEnergy; i++)
                {
                    for (int j = 0; j < RobotSettings.MaxCellForGettingEnergy; j++)
                    {
                        if (stationPosition.X + i == Robot.Position.X || stationPosition.Y + j == Robot.Position.Y)
                        {
                            Position = new Position(stationPosition.X + i, stationPosition.Y + j);
                        }
                        if (stationPosition.X - i == Robot.Position.X || stationPosition.Y - j == Robot.Position.Y)
                        {
                            Position = new Position(stationPosition.X - i, stationPosition.Y - j);
                        }
                        if (stationPosition.X - i == Robot.Position.X || stationPosition.Y + j == Robot.Position.Y)
                        {
                            Position = new Position(stationPosition.X - i, stationPosition.Y + j);
                        }
                        if (stationPosition.X + i == Robot.Position.X || stationPosition.Y - j == Robot.Position.Y)
                        {
                            Position = new Position(stationPosition.X + i, stationPosition.Y - j);
                        }
                    }
                }
            }
        }
    }
}
