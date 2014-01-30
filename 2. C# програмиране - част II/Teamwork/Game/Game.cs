using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Game
{
	class Game
	{
		//private static Asteroid asteroids = new Asteroid();
		Asteroid asteroids = new Asteroid();
		public static int asteroidCount = 0;
		public static int maxAsteroidCount = 5;
		static void Main()
		{
			Field.GetFieldOptions();

			//while (asteroidCount<maxAsteroidCount)
			//{
			//	asteroids.a
			//}

			while(true)
			{
				Field.ShowStatus();
				Field.CheckForAvailableKey();


				//TODO: add class Asteroids, they will be 3 different types, for now they will die from one shot

				//here add foreach print asteroids

				ThorShip.PrintObject(ThorShip.Player, ThorShip.PlayerCoordinates, type: "player");
				Asteroid.Movement();
				Asteroid.PrintObject(Asteroid.asteroidType1, Asteroid.AsteroidCoordinates, type: "asteroid");
				Asteroid.PrintObject(Asteroid.asteroidType2, Asteroid.AsteroidCoordinates2, type: "asteroid");
				

				Thread.Sleep(Field.Speed);
				Console.Clear();
			}
		}
	}
}
