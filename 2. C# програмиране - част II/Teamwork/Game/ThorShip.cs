using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
	class ThorShip:GameObject
	{
		public static List<Coordinates> PlayerCoordinates = new List<Coordinates>();
		public static char[,] Player = 
        {
            {'ʌ', ' ', ' ', ' ',' ',' ',},
			{'«', ' ','#', '=','-', '>', },
			{'˅', ' ', ' ', ' ',' ',' ',}
        };
		public static int PlayerShootSpeed = 30;
		public static int PlayerMaxShoots = 3;
		public static int PlayerShootsAlive = 0;
		private static Coordinates weaponCoords;

		static ThorShip()
        {
			ThorShip.SetObjectCoords(Player, PlayerCoordinates, 2, (Console.WindowHeight / 2) - 3);
			weaponCoords = new Coordinates(PlayerCoordinates[0].Row, PlayerCoordinates[0].Col);
        }

		//TODO: implement shooting systems
		public static void Shoot()
		{

		}

		public static void MoveUp(int step = -1)
		{
			for (int i = 0; i < PlayerCoordinates.Count; i++)
			{
				int nextRow = PlayerCoordinates[i].Row + step;

				if (nextRow < 0) nextRow = Console.WindowHeight - 5;
				else if (nextRow >= Console.WindowHeight - 4) nextRow = 0;

				PlayerCoordinates[i] = new Coordinates(nextRow, PlayerCoordinates[i].Col);
			}

			#region [Removes, Draws and Moves weapon of the ship]

			int next = weaponCoords.Row + step;

			if (next < 0) next = Console.WindowHeight - 5;
			else if (next >= Console.WindowHeight - 4) next = 0;

			weaponCoords = PlayerCoordinates[0] = new Coordinates(next, weaponCoords.Col);

			#endregion
		}
		
		public static void MoveDown()
		{
			MoveUp(1);
		}

		public static void MoveLeft(int step = -1)
		{
			for (int i = 0; i < PlayerCoordinates.Count; i++)
			{
				int nextColumn = PlayerCoordinates[i].Col + step;

				if (nextColumn < 0) nextColumn = Console.WindowWidth - 1;
				else if (nextColumn >= Console.WindowWidth) nextColumn = 0;

				PlayerCoordinates[i] = new Coordinates(PlayerCoordinates[i].Row, nextColumn);
			}

			#region [Removes, Draws and Moves weapon of the ship]

			int next = weaponCoords.Col + step;

			if (next < 0) next = Console.WindowWidth - 1;
			else if (next >= Console.WindowWidth) next = 0;

			weaponCoords = PlayerCoordinates[0] = new Coordinates(weaponCoords.Row, next);

			#endregion
		}

		public static void MoveRight()
		{
			MoveLeft(1);
		}
	}
}
