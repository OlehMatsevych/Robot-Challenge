using OlehMatsevych.RobotChallange.Constants;
using Robot.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OlehMatsevych.RobotChallange.Constants.Settings;
using Hero = Robot.Common.Robot;

namespace OlehMatsevych.RobotChallange.Algorithms
{
    public class EnableEnergyDistance
    {
        public MovingTypes CheckForCollectType(Position stationPosition, Hero robot )
        {
            try
            {
                if (stationPosition == null)
                    return MovingTypes.Move;
                else if (stationPosition.X >= robot.Position.X && stationPosition.Y >= robot.Position.Y)    //3
                {
                    //(-inf;-inf)

                    int i = 0;
                    for ( i = robot.Position.X; i <= stationPosition.X; i++)
                    {
                        if (i == stationPosition.X - 2)
                            break;
                    }
                    int j = 0;
                    for (j = robot.Position.Y; j <= stationPosition.Y; j++)
                    {
                        if (j == stationPosition.Y - 2)
                            break;
                    }

                    if ((Math.Abs(i - stationPosition.X) <= 2)
                        && (Math.Abs(j - stationPosition.Y) <= 2))
                        return MovingTypes.Collect;
                }
                else if (stationPosition.X >= robot.Position.X && stationPosition.Y <= robot.Position.Y)   //1
                {
                    //(-inf;+inf)

                    int i = 0;
                    for (i = robot.Position.X; i <= stationPosition.X; i++)
                    {
                        if (i == stationPosition.X - 2)
                            break;
                    }
                    int j = 0;
                    for (j = robot.Position.Y; j >= stationPosition.Y; j--)
                    {
                        if (j == stationPosition.Y + 2)
                            break;
                    }

                    if ((Math.Abs(i - stationPosition.X) <= 2)
                        && (Math.Abs(j - stationPosition.Y) <= 2))
                        return MovingTypes.Collect;

                }
                else if (stationPosition.X < robot.Position.X && stationPosition.Y > robot.Position.Y)   //4
                {
                    //(+inf;-inf)

                    int i = 0;
                    for (i = robot.Position.X; i >= stationPosition.X; i--)
                    {
                        if (i == stationPosition.X + 2)
                            break;
                    }
                    int j = 0;
                    for (j = robot.Position.Y; j <= stationPosition.Y; j++)
                    {
                        if (j == stationPosition.Y - 2)
                            break;
                    }

                    if ((Math.Abs(i - stationPosition.X) <= 2)
                        && (Math.Abs(j - stationPosition.Y) <= 2))
                        return MovingTypes.Collect;
                }
                else if (stationPosition.X < robot.Position.X && stationPosition.Y < robot.Position.Y)   //2
                {
                    //(+inf;+inf)

                    int i = 0;
                    for (i = robot.Position.X; i >= stationPosition.X; i--)
                    {
                        if (i == stationPosition.X + 2)
                            break;
                    }
                    int j = 0;
                    for (j = robot.Position.Y; j >= stationPosition.Y; j--)
                    {
                        if (j == stationPosition.Y + 2)
                            break;
                    }

                    if ((Math.Abs(i - stationPosition.X) <= 2)
                        && (Math.Abs(j - stationPosition.Y) <= 2))
                        return MovingTypes.Collect;
                }
                return MovingTypes.Move;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
