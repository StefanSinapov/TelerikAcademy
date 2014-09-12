using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plane
{
    public class AsteroidGenerator : IAsteroidGenerate
    {
        public int RowsField { get; set; }
        public int ColsField { get; set; }
        Random randomGenerator = new Random();
               

        public AsteroidGenerator(int rowsField, int colsField)
        {
            this.RowsField = rowsField;
            this.ColsField = colsField;
        }

        public GameObject RandomGenerateAsteroid()
        {
            GameObject possibleAsteroid = new Asteroid();

            if (randomGenerator.Next(0, 101) > 70) //30% of time will generate asteroid
            {
                possibleAsteroid = CreateAsteroid();
            }

            return possibleAsteroid;
        }

        private GameObject CreateAsteroid()
        {
            Coord asteroidCoord = new Coord(randomGenerator.Next(0, this.RowsField), this.ColsField - 2);

            return new Asteroid(asteroidCoord, new char[,] {{'#'}},ObjectTypes.Asteroid, -1);
        }
        
    }
}
