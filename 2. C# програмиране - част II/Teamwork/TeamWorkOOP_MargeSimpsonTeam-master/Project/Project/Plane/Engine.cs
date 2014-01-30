using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Plane
{
    public class Engine
    {
        private IDrawer drawer;
        private IAsteroidGenerate asteroidGenerator;
        private IUserInterface userInterface;
        private List<GameObject> allObjects;
        public int WorldRows { get; set; }
        public int WorldCols { get; set; }

        public Engine(IDrawer drawer, IAsteroidGenerate asteroidGenerator, IUserInterface userInterface, int worldRows, int worldCols)
        {
            this.drawer = drawer;
            this.allObjects = new List<GameObject>();
            this.userInterface = userInterface;
            this.asteroidGenerator = asteroidGenerator;
            this.WorldRows = worldRows;
            this.WorldCols = worldCols;
        }

        public void AddGameObject(GameObject gameObject)
        {
            this.allObjects.Add(gameObject);
        }
        public void AddAsteroid()
        {
            this.allObjects.Add(asteroidGenerator.RandomGenerateAsteroid());
        }

        private void DrawAllOBjects()
        {
            EnqueAllObjects();
            drawer.DrawAll();
        }

        private void EnqueAllObjects()
        {
            foreach (var obj in this.allObjects)
            {
                if (obj.Alive)
                {
                    drawer.EnqueueForDrawing(obj);
                }
            }
        }

        private void UpdateAll()
        {
            foreach (var obj in this.allObjects)
            {
                if (obj.Alive && obj.TopLeft.Col + obj.Image.GetLength(1) >= this.WorldCols || obj.TopLeft.Col <= 0)
                {
                    obj.Alive = false;
                }
                obj.Update();
            }
        }

        private void Clear()
        {
            drawer.Clear();
            allObjects.RemoveAll(x => x.Alive == false);
            //allObjects.RemoveAll(x => string.IsNullOrEmpty(x.TopLeft.ToString()));

        }


        public void Fly()
        {
            while (true)
            {
                EnqueAllObjects();

                CheckForCollisions();

                DrawAllOBjects();

                WriteLogo();

                Thread.Sleep(200);

                AddAsteroid();

                Clear();

                UpdateAll();

                this.userInterface.CheckForInput();

            }
        }

        private void WriteLogo()
        {
            Console.SetCursorPosition(WorldRows, 0);
            Console.WriteLine("Team \"Marge Simpson\" 2013");
        }

        private void CheckForCollisions()
        {
            for (int leftObj = 0; leftObj < this.allObjects.Count; leftObj++)
            {
                for (int rightObj = 0; rightObj < allObjects.Count; rightObj++)
                {
                    if (Colide(this.allObjects[leftObj], this.allObjects[rightObj]))
                    {
                        this.allObjects[leftObj].Alive = false;
                        this.allObjects[rightObj].Alive = false;

                    }
                }
            }
        }

        private bool Colide(GameObject leftObj, GameObject rightObj)
        {
            bool result = false;

            int leftRowsLenght = leftObj.TopLeft.Row + leftObj.Image.GetLength(0);
            int rightRowsLenght = rightObj.TopLeft.Row + rightObj.Image.GetLength(0);

            int leftObjLastCol = leftObj.TopLeft.Col + leftObj.Image.GetLength(1);
            int rightObjFirstCol = rightObj.TopLeft.Col;

            if (leftObjLastCol == rightObjFirstCol)
            {
                for (int rowLeftIndex = leftObj.TopLeft.Row; rowLeftIndex < leftRowsLenght; rowLeftIndex++)
                {
                    for (int rowRightIndex = rightObj.TopLeft.Row; rowRightIndex < rightRowsLenght; rowRightIndex++)
                    {
                        if (rowLeftIndex == rowRightIndex)
                        {
                            return true;
                        }
                    }
                }
            }

            return result;
        }


        internal void MovePlaneUp()
        {
            FindPlane().Move(new Coord(1, 0));
        }

        internal void MovePlaneDown()
        {
            FindPlane().Move(new Coord(-1, 0));
        }

        internal void ProduceObject()
        {
            this.allObjects.AddRange(FindPlane().ProduceObject(new Rocket(new Coord(FindPlane().TopLeft.Row + 1, FindPlane().TopLeft.Col + 3), new char[,] { { '-', '*' } }, ObjectTypes.Rocket, 1)));
        }

        private GameObject FindPlane()
        {
            return this.allObjects.Find(x => x.ObjectType == ObjectTypes.Plane);
        }

    }
}
