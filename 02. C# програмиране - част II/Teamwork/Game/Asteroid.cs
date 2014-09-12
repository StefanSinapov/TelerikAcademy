using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Game
{
	class Asteroid : GameObject
	{
		static Random rand = new Random();
		public static List<Coordinates> AsteroidCoordinates = new List<Coordinates>();
		public static List<Coordinates> AsteroidCoordinates2 = new List<Coordinates>();
		public static List<Coordinates> AsteroidCoordinates3 = new List<Coordinates>();
		//TODO: add different types
		public static char[,] asteroidType1 =
		{
			{'*','*'},
			{'*','*'}
		};
		public static char[,] asteroidType2 =
		{
			{'*','*','*'},
			{'*','*','*'},
			{'*','*','*'}
		};
		public static char[,] asteroidType3 =
		{
			{'<','*','*'},
			{'<','*','*'}
		};
		public static int asteroidCount = 0;
		public static int maxAsteroidCount = 5;
		public static int movementSpeed = 1;


		static Asteroid()
		{
			
			Asteroid.SetObjectCoords(asteroidType1, AsteroidCoordinates, Console.BufferWidth - 2, rand.Next(0, Console.BufferHeight - 4));
			Asteroid.SetObjectCoords(asteroidType2, AsteroidCoordinates2, Console.BufferWidth - 2, rand.Next(0, Console.BufferHeight - 7));

		}

		public static void Movement()
		{
			for (int i = 0; i < AsteroidCoordinates.Count; i++)
			{
				int nextColumn = AsteroidCoordinates[i].Col - movementSpeed;

				if (nextColumn < 0) nextColumn = Console.WindowWidth - 1;
				else if (nextColumn >= Console.WindowWidth) nextColumn = 0;

				AsteroidCoordinates[i] = new Coordinates(AsteroidCoordinates[i].Row, nextColumn);
			}
			for (int i = 0; i < AsteroidCoordinates2.Count; i++)
			{
				int nextColumn = AsteroidCoordinates2[i].Col - movementSpeed;

				if (nextColumn < 0) nextColumn = Console.WindowWidth - 1;
				else if (nextColumn >= Console.WindowWidth) nextColumn = 0;

				AsteroidCoordinates2[i] = new Coordinates(AsteroidCoordinates2[i].Row, nextColumn);
			}
		}


		//private static void PrintInvaders(int type)
		//{
		//	List<Coordinates[]> currentInvaders;
		//	string[] currentShipType;

		//	switch (type)
		//	{
		//		case 1: currentInvaders = InvaderCoords1; currentShipType = Ship1; Console.ForegroundColor = ConsoleColor.Cyan; break;
		//		case 2: currentInvaders = InvaderCoords2; currentShipType = Ship2; Console.ForegroundColor = ConsoleColor.Yellow; break;
		//		case 3: currentInvaders = InvaderCoords3; currentShipType = Ship3; Console.ForegroundColor = ConsoleColor.DarkCyan; break;
		//		default: return;
		//	}

		//	for (int i = 0; i < currentInvaders.Count; i++)
		//	{
		//		if (currentInvaders[i] != null)
		//		{
		//			for (int j = 0; j < 3; j++)
		//			{
		//				Console.SetCursorPosition(currentInvaders[i][0].Col, currentInvaders[i][0].Row - 2 + j);
		//				Console.Write(string.Join("", currentShipType[j]));
		//			}
		//		}
		//	}

		//	Console.ForegroundColor = ConsoleColor.Gray;
		//}
	}

}
