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
            List<Rock> rocksToRemove = new List<Rock>();
            List<Rock> shotsToRemove = new List<Rock>();

            for (int rock = 0; rock < ThorShip.rocks.Count; rock++)
            {
                for (int shot = 0; shot < Shooting.shots.Count; shot++)
                {
                    if (ThorShip.rocks[rock].X == Shooting.shots[shot].X
                          && ThorShip.rocks[rock].Y == Shooting.shots[shot].Y)
                    {
                        rocksToRemove.Add(ThorShip.rocks[rock]);
                        shotsToRemove.Add(Shooting.shots[shot]);

                        Field.Score++;
                    }

                }
            }

            List<Rock> newRocks = new List<Rock>();
            List<Rock> newShots = new List<Rock>();

            for (int i = 0; i < ThorShip.rocks.Count; i++)
            {
                if (!rocksToRemove.Contains(ThorShip.rocks[i]))
                {
                    newRocks.Add(ThorShip.rocks[i]);
                }
            }

            for (int i = 0; i < Shooting.shots.Count; i++)
            {
                if (!shotsToRemove.Contains(Shooting.shots[i]))
                {
                    newShots.Add(Shooting.shots[i]);
                }
            }

            ThorShip.rocks = newRocks;
            Shooting.shots = newShots;
        }

        

    }
}

