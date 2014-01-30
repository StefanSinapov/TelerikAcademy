using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plane
{
    public class PlaneStarter
    {
        const int ROWSFIELD = 15;
        const int COLSFIELD = 40;

        static void Main()
        {
            try
            {
                ConsoleDrawer drawer = new ConsoleDrawer(ROWSFIELD, COLSFIELD);
                IUserInterface keyboard = new KeyboardInterface();
                AsteroidGenerator asteroidGenerator = new AsteroidGenerator(ROWSFIELD, COLSFIELD);

                Engine gameEngine = new Engine(drawer, asteroidGenerator, keyboard, ROWSFIELD, COLSFIELD);
                

                Initialize(gameEngine);
               

                keyboard.OnDownKeyPressed += (sender, eventInfo) =>
                {
                    gameEngine.MovePlaneUp();
                };

                keyboard.OnUpKeyPressed += (sender, eventInfo) =>
                    {
                        gameEngine.MovePlaneDown();
                    };

                keyboard.OnFireKeyPressed += (sender, eventInfo) =>
                    {
                        gameEngine.ProduceObject();
                    };



                gameEngine.Fly();
            }
            catch (PlaneException ex)
            {
                Console.WriteLine(ex.PlaneMessage);
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static Engine Initialize(Engine gameEngine)
        {   
            Plane plane = new Plane(new Coord(9, 1), new char[,] { { '>', ' ' }, { ' ', '>' }, { '>', ' ' } }, ObjectTypes.Plane);

            gameEngine.AddGameObject(plane);          

            return gameEngine;
        }
    }
}
