using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThorShip
{
    class Shooting
    {
        public  static List<Rock> shots = new List<Rock>(); // added by Dobrin

        public static void Shoot(char direction)
        {
            if (direction == 'l')
            {
                Rock shot = new Rock(direction,1,1,ConsoleColor.Cyan);
                shot.RockSymbol = '*';
                shot.X = ThorShip.userShip.YCoordinate + ThorShip.userShip.Size - 2;
                shot.Y = ThorShip.userShip.XCoordinate + 1;

                shots.Add(shot);
            }

            if (direction == 'r')
            {
                Rock shot = new Rock(direction, 1, 1, ConsoleColor.Cyan);
                shot.RockSymbol = '*';
                shot.X = ThorShip.userShip.YCoordinate + ThorShip.userShip.Size - 2;
                shot.Y = ThorShip.userShip.XCoordinate + ThorShip.userShip.Size - 2 ;

                shots.Add(shot);
            }

            if (direction == 'u')
            {
                Rock shot = new Rock(direction, 1, 1, ConsoleColor.Cyan);
                shot.RockSymbol = '*';
                shot.X = ThorShip.userShip.YCoordinate + 1;
                shot.Y = ThorShip.userShip.XCoordinate + ThorShip.userShip.Size / 2;

                shots.Add(shot);
            }

            if (direction == 'd')
            {
                Rock shot = new Rock(direction, 1, 1, ConsoleColor.Cyan);
                shot.RockSymbol = '*';
                shot.X = ThorShip.userShip.YCoordinate + ThorShip.userShip.Size-2;
                shot.Y = ThorShip.userShip.XCoordinate + ThorShip.userShip.Size / 2;

                shots.Add(shot);
            }

        }

        public static void MoveShots()
        {
            int shotSpeed = 2;
            
            for (int i = 0; i < shots.Count; i++)
            {
                //move left
                if (shots[i].Position == 'l')
                {
                    if (shots[i].Y > shotSpeed)
                    {
                        shots[i].Y = shots[i].Y - shotSpeed;
                    }
                    else if (shots[i].Y == shotSpeed)
                    {
                        shots[i].Y = shots[i].Y - (shotSpeed - 1);
                    }
                    else if (shots[i].Y < shotSpeed && shots[i].Y > 0)
                    {
                        shots[i].Y = 0;
                    }
                }

                //move right
                if (shots[i].Position == 'r')
                {
                    if (shots[i].Y + shotSpeed < Console.BufferWidth )
                    {
                        shots[i].Y = shots[i].Y + shotSpeed;
                    }
                    else if (shots[i].Y + shotSpeed == Console.BufferWidth)
                    {
                        shots[i].Y = shots[i].Y + (shotSpeed - 1);
                    }
                    else if (shots[i].Y + shotSpeed > Console.BufferWidth)
                    {
                        shots[i].Y = Console.BufferWidth - 1;
                    }
                }

                //move up
                if (shots[i].Position == 'u')
                {
                    if (shots[i].X > shotSpeed)
                    {
                        shots[i].X = shots[i].X - shotSpeed;
                    }
                    else if (shots[i].X == shotSpeed)
                    {
                        shots[i].X = shots[i].X - (shotSpeed-1);
                    }
                    else if (shots[i].X > 0)
                    {
                        shots[i].X = 0;
                    }

                }

                //move down
                if (shots[i].Position == 'd')
                {
                    if (shots[i].X + shotSpeed < Console.BufferHeight - Field.StatusBar)
                    {
                        shots[i].X = shots[i].X + shotSpeed;
                    }
                    else if (shots[i].X + shotSpeed == Console.BufferHeight - Field.StatusBar)
                    {
                        shots[i].X = shots[i].X + (shotSpeed - 1);
                    }
                    else if (shots[i].X + shotSpeed > Console.BufferHeight - Field.StatusBar)
                    {
                        shots[i].X = Console.BufferHeight - Field.StatusBar;
                    }
                }
            }

            //Check if next move is out of field
            int index = -1;
            for (int i = 0; i < shots.Count; i++)
            {
                if (shots[i].Y  <= 0 || shots[i].Y >= Console.BufferWidth - 1
                    || shots[i].X <= 0 || shots[i].X >= Console.BufferHeight - Field.StatusBar)
                {
                    index = i;
                    break;
                }
            }

            //Remove shot if is it os out of filed
            if (index != -1)
            {
                shots.RemoveAt(index);
            }
        }
     
        public static void PrintShots()
        {
            foreach (Rock shot in shots)
            {
                shot.DrowRock();
            }
        }

    }
}
