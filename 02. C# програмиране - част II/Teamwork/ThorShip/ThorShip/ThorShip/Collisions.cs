using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThorShip
{
    class Collisions
    {

        public static void HandleCollisionsRocksShots()
        {
            for (int rock = 0; rock < ThorShip.rocks.Count; rock++)
            {
                for (int shot = 0; shot < Shooting.shots.Count; shot++)
                {
                    bool xCollision = false;
                    bool yCollision = false;
                    
                    for (int i = ThorShip.rocks[rock].X  ; i < ThorShip.rocks[rock].X  + ThorShip.rocks[rock].Height ; i++)
                    {
                        if (Shooting.shots[shot].X == i)
                        {
                             xCollision = true;
                              break;
                        }
                    }

                    for (int i = ThorShip.rocks[rock].Y; i < ThorShip.rocks[rock].Y + ThorShip.rocks[rock].Width; i++)
                    {
                        if (Shooting.shots[shot].Y == i)
                        {
                            yCollision = true;
                            break;
                        }
                    }

                    if (xCollision && yCollision) 
                    {
                        ThorShip.rocks[rock].ReinitiateRock();
                        Field.Score += ThorShip.rocks[rock].Height*ThorShip.rocks[rock].Width;

                    }
                }
            }
       
        }

        public static void CollisionDetection()
        {
            foreach (Rock item in ThorShip.rocks)
            {
                if (item.Y + item.Width > ThorShip.userShip.XCoordinate && item.Y < ThorShip.userShip.XCoordinate + ThorShip.userShip.Size)
                {
                    if (item.X + item.Height > ThorShip.userShip.YCoordinate && item.X < ThorShip.userShip.YCoordinate + ThorShip.userShip.Size)
                    {
                        if (Field.LivesCount > 1)
                        {
                            Field.LivesCount--;
                            item.ReinitiateRock();
                        }
                        else
                        {
                            GameOver();
                        }
                    }
                }
            }
        }
        private static void GameOver()
        {
            ThorShip.gameMenu.GameOverScreen(Field.Score);
            ThorShip.maximumRocks = 15;
            foreach (Rock r in ThorShip.rocks)
            {
                r.ReinitiateRock();
            }

        }
    }
}
