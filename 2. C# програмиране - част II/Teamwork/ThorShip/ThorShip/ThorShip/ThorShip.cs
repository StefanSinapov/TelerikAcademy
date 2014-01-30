using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThorShip
{
    class ThorShip
    {

        public static Menu gameMenu = new Menu();
        public static Ship userShip = new Ship(7);
        public static List<Rock> rocks = new List<Rock>();
        static Random random = new Random();
        static char[] rockSpawningPositions = { 'u', 'd', 'l', 'r' };
        static int currentRocks = 0;
        public static int maximumRocks = 15; // Increase when some time passes...

        static void Main()
        {
            gameMenu.WelcomeScreen(false);

            Field.GetFieldOptions();
            userShip.XCoordinate = (Console.BufferWidth - userShip.Size) / 2;
            userShip.YCoordinate = (Console.BufferHeight - userShip.Size) / 2;
            int frames = 0;
            while (true)
            {

                Console.Clear();
                Field.ShowStatus();


                userShip.MoveShip();
                userShip.DrawShip(userShip.XCoordinate, userShip.YCoordinate);
                Collisions.HandleCollisionsRocksShots();
                GenerateRocks();
                MoveRocks();
                Collisions.CollisionDetection();
                PrintRocks();

                Shooting.MoveShots();
                Shooting.PrintShots();

                if(frames%300==0)
                {
                    maximumRocks += 2;
                }

                frames++;
                System.Threading.Thread.Sleep(150);

            }

        }

        #region UsedMethods
        
       
        static void GenerateRocks()
        {

            //Generate rocks.
            if (currentRocks < maximumRocks)
            {
                Rock rock = new Rock(rockSpawningPositions[random.Next(0, 4)]);
                rock.ReinitiateRock();
                rocks.Add(rock);
                currentRocks++;
            }

        }

        //if the rock goes to the end of the other side resets position(prevents out of Range exception)
        static void MoveRocks()
        {
            foreach (Rock r in rocks)
            {
                switch (r.Position)
                {
                    case 'u': if (r.X < Console.WindowHeight - r.Height - Field.StatusBar) { r.X++; }
                        else { r.ReinitiateRock(); } break;
                    case 'l': if (r.Y < Console.WindowWidth - r.Width) { r.Y++; }
                        else { r.ReinitiateRock(); } break;
                    case 'r': if (r.Y > 0 + r.Width) { r.Y--; }
                        else { r.ReinitiateRock(); } break;
                    case 'd': if (r.X > 0 + r.Height) { r.X--; }
                        else {r.ReinitiateRock(); } break;
                }
            }
        }

        static void PrintRocks()
        {
            foreach (Rock r in rocks)
            {
                r.DrowRock();
            }
        }


        #endregion

    }
}
