using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
	class Field
	{
		//public static List<RankList> Ranklist = new List<RankList>();
		public static int Score = 0, LivesCount = 3;
		public static int Speed = 300;
		public static bool IsChangedStatus = true, IsChangedScore = false;
		static string lines;

		public static void GetFieldOptions()
		{
			Console.Title = "Thor Ship!";

			Console.InputEncoding = Encoding.UTF8;
			Console.OutputEncoding = Encoding.UTF8;

			Console.BufferHeight = Console.WindowHeight = 35;
			Console.BufferWidth = Console.WindowWidth = 95;

			lines = " <" + new string('-', Console.WindowWidth - 4) + ">";

			Console.CursorVisible = false;
			Console.TreatControlCAsInput = true;
		}

		public static void ShowStatus()
		{
			IsChangedStatus = false;

			Console.SetCursorPosition(0, Console.WindowHeight - 3);
			Console.WriteLine("{0}\n SCORE: {1:0000} {2} | THOR SHIP | {2} LIVES: {3}\n{0}",
				lines, Score, new string(' ', Console.BufferWidth / 2 - 29), new string('♥', LivesCount).PadRight(3, ' '));
		}
		public static void CheckForAvailableKey()
		{
			while (Console.KeyAvailable)
			{
				ConsoleKeyInfo userKey = Console.ReadKey(true);

				if (userKey.Key == ConsoleKey.LeftArrow)
				{
					ThorShip.MoveLeft();
				}
				else if (userKey.Key == ConsoleKey.RightArrow)
				{
					ThorShip.MoveRight();
				}
				else if (userKey.Key == ConsoleKey.UpArrow)
				{
					ThorShip.MoveUp();
				}
				else if (userKey.Key == ConsoleKey.DownArrow)
				{
					ThorShip.MoveDown();
				}
				else if (userKey.Key == ConsoleKey.Escape)
				{
					Console.Clear();
					Environment.Exit(Environment.ExitCode);
				}
				else if (ThorShip.PlayerShootsAlive < ThorShip.PlayerMaxShoots && (userKey.Key == ConsoleKey.Spacebar || userKey.Key == ConsoleKey.Enter))
				{
					//Thread shoot = new Thread(PlayerShip.Shoot);

					//	shoot.Start();
				}
			}
		}
	}
}
