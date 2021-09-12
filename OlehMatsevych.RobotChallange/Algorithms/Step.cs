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
    public class Step
    {
        private static IList<Hero> Robots { get; set; }
        private static int RobotToMoveIndex { get; set; }
        private Map Map { get; set; }
        private Hero Robot { get; set; } = Robots[RobotToMoveIndex]; 



        private Position Position { get; set; }
        private RobotTypeByEnergy RobotType { get; set; }
        private MovingTypes MovingType { get; set; }
        private delegate void Executer();
        private delegate void PriorityAlgorithn();

        public Step(IList<Hero> robots, int robotToMoveIndex, Map map)
        {
            Robots = robots;
            RobotToMoveIndex = robotToMoveIndex;
            Map = map;
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
            /*
             В приооритеті розмноження, довгі пересування 
             */
            if ((Robot.Energy > MinEnergyForCreateNewRobot) && (Robots.Count < Map.Stations.Count))
            {
                MovingType = MovingTypes.Move;
            }
            StationHelper stationHelper = new StationHelper();
            Position stationPosition = stationHelper.FindNearestFreeStation(Robot, Map, Robots);
            if (stationPosition == Robot.Position)
            {
                MovingType = MovingTypes.Collect;
            }
            else
            {
                Position = stationPosition;
                MovingType = MovingTypes.Move;
            }
        }
        private void StrongAlgo()
        {           
             /*
                В приооритеті розмноження, середні пересування
             */
            if ((Robot.Energy > MinEnergyForCreateNewRobot) && (Robots.Count < Map.Stations.Count))
            {
                MovingType = MovingTypes.Move;
            }
            StationHelper stationHelper = new StationHelper();
            Position stationPosition = stationHelper.FindNearestFreeStation(Robot, Map, Robots);
            if (stationPosition == Robot.Position)
            {
                MovingType = MovingTypes.Collect;
            }
            else
            {
                Position = stationPosition;
                MovingType = MovingTypes.Move;
            }
        }
        private void MiddleAlgo()
        {
            /*
                В приооритеті збереження енергії, короткі пересування 
            */
            if ((Robot.Energy > MinEnergyForCreateNewRobot) && (Robots.Count < Map.Stations.Count))
            {
                MovingType = MovingTypes.Move;
            }
            StationHelper stationHelper = new StationHelper();
            Position stationPosition = stationHelper.FindNearestFreeStation(Robot, Map, Robots);
            if (stationPosition == Robot.Position)
            {
                MovingType = MovingTypes.Collect;
            }
            else
            {
                Position = stationPosition;
                MovingType = MovingTypes.Move;
            }
        }
        private void JuniorAlgo()
        {
            /*
                В приооритеті збереження енергії, короткі пересування 
            */
            if ((Robot.Energy > MinEnergyForCreateNewRobot) && (Robots.Count < Map.Stations.Count))
            {
                MovingType = MovingTypes.Move;
            }
            StationHelper stationHelper = new StationHelper();
            Position stationPosition = stationHelper.FindNearestFreeStation(Robot, Map, Robots);
            if (stationPosition == Robot.Position)
            {
                MovingType = MovingTypes.Collect;
            }
            else
            {
                Position = stationPosition;
                MovingType = MovingTypes.Move;
            }
        }
    }
}
