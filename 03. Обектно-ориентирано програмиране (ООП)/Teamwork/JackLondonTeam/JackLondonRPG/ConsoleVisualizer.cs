using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackLondonRPG
{
	public static class ConsoleVisualizer
	{
		public const int cannonBuffer = 4;
		public const int wallBuffer = 6;
		public const int shipHealthBuffer = 4;
		public const int distanceBetweenShips = 10;

		public static void ClearScreen()
		{
			Console.Clear();	
		}

		public static void VisualizeDrawable(IDrawable drawable)
		{
			var img = drawable.GetImage();
			int rows = img.GetLength(0);
			int cols = img.GetLength(1);

			for (int i = 0; i < rows; ++i)
			{
				for (int j = 0; j < cols; ++j)
				{
					Console.Write(img[i, j]);
				}
				Console.WriteLine();
			}
		}

		public static void VisualizeMerchant(Merchant merchant)
		{
			Console.WriteLine("Merchant " + merchant.Name);
			Console.WriteLine("Price to upgrade cannon: " + merchant.PricePerRankUpCannon);
			Console.WriteLine("Price to upgrade wall: " + merchant.PricePerRankWall);
		}

		public static void VisualizeRepairman(Repairman repairman)
		{
			Console.WriteLine("Repairman " + repairman.Name);
			Console.WriteLine("Price to rapair wall(1 point): " + repairman.PricePerPointRepair);
		}

		public static void VisualizeShip(Ship ship)
		{
			int numberOfShipsRows = ship.Cannons.Count;
			int middleRow = numberOfShipsRows / 2;

			for (int i = 0; i < numberOfShipsRows; ++i)
			{
				if (i == numberOfShipsRows)
				{
					Console.Write(ship.CurrHealth.ToString().PadRight(shipHealthBuffer, '*'));
				}

				else
				{
					Console.Write(new string('*', shipHealthBuffer));
				}

				VisualizeCannon(ship.Cannons[i], true);
				VisualizeWall(ship.Walls[i], true);

				Console.WriteLine();
			}
		}

		public static void VisualizeBattleState(Ship firstShip, Ship secondShip)
		{
			int numberOfShipsRows = firstShip.Cannons.Count;
			int middleRow = numberOfShipsRows / 2;

			for (int i = 0; i < numberOfShipsRows; ++i)
			{
				if (i == numberOfShipsRows)
				{
					Console.Write(firstShip.CurrHealth.ToString().PadRight(shipHealthBuffer, '*'));
				}

				else
				{
					Console.Write(new string('*', shipHealthBuffer));
				}

				VisualizeCannon(firstShip.Cannons[i], true);
				VisualizeWall(firstShip.Walls[i], true);

				for (int j = 0; j < distanceBetweenShips; ++j)
				{
					Console.Write('.');
				}

				VisualizeCannon(secondShip.Cannons[i], false);
				VisualizeWall(secondShip.Walls[i], false);

				if (i == numberOfShipsRows)
				{
					Console.Write(secondShip.CurrHealth.ToString().PadLeft(shipHealthBuffer, '*'));
				}

				Console.WriteLine();
			}

            //foreach (var gameEvent in events)
            //{
            //    VisualizeDrawable(gameEvent);
            //    Console.WriteLine();
            //}
		}

		public static void VisualizeCannon(Cannon cannon, bool padRight)
		{
			StringBuilder cannonStr = new StringBuilder();
			cannonStr.Append(cannon.GetDamage().ToString());
			char[,] cannonImg = cannon.GetImage();

			for (int i = 0; i < cannonImg.GetLength(1); ++i)
			{
				cannonStr.Append(cannonImg[0, i]);
			}

			if (padRight)
			{
				Console.Write(cannonStr.ToString().PadRight(cannonBuffer, '*'));
			}
			else
			{
				Console.Write(cannonStr.ToString().PadLeft(cannonBuffer, '*'));
			}
		}
		public static void VisualizeWall(Wall wall, bool padRight)
		{
			StringBuilder wallStr = new StringBuilder();
			wallStr.Append(wall.CurrHealth);
			wallStr.Append(wall.MaxHealth.CurrValue);
			char[,] wallImg = wall.GetImage();

			for (int i = 0; i < wallImg.GetLength(1); ++i)
			{
				wallStr.Append(wallImg[0, i]);
			}

			if (padRight)
			{
				Console.Write(wallStr.ToString().PadRight(cannonBuffer, '*'));
			}
			else
			{
				Console.Write(wallStr.ToString().PadLeft(cannonBuffer, '*'));
			}
		}


	}
}
