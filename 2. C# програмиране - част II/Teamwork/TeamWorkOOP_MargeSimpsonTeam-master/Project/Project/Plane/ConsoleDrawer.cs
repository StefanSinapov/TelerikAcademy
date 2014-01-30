using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plane
{
    public class ConsoleDrawer : IDrawer
    {
        private List<GameObject> gameObjects;
        private int worldRows;
        private int worldCols;

        public List<GameObject> GameObjects
        {
            get
            {
                return this.gameObjects;
            }
        }

        public void EnqueueForDrawing(GameObject gameObject)
        {
            if (gameObject.Alive)
            {
                this.GameObjects.Add(gameObject);
            }
        }

        public ConsoleDrawer(int worldRows, int worldCols)
        {
            this.gameObjects = new List<GameObject>();
            this.worldCols = worldCols;
            this.worldRows = worldRows;
        }

        public void DrawAll()
        {
            foreach (var obj in this.GameObjects)
            {
                Console.SetCursorPosition(obj.TopLeft.Col, obj.TopLeft.Row);
                char[,] image = obj.Image;

                for (int i = 0; i < image.GetLength(0); i++)
                {
                    for (int j = 0; j < image.GetLength(1); j++)
                    {
                        Console.Write(image[i, j]);
                    }
                    Console.SetCursorPosition(obj.TopLeft.Col, obj.TopLeft.Row + i + 1);
                }
            }

        }

        public void Clear()
        {
            Console.Clear();
            this.gameObjects.Clear();
        }
    }
}
