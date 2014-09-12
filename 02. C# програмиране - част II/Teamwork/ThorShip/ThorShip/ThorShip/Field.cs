using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThorShip
{
	class Field
	{
		//public static List<RankList> Ranklist = new List<RankList>();
        public static int Score = 0, LivesCount = 3;
		public static int Speed = 300;
		public static bool IsChangedStatus = true, IsChangedScore = false;
		public const int StatusBar = 4;
		static string lines;

		public static void GetFieldOptions()
		{
			Console.Title = "Thor Ship Game!";

			Console.InputEncoding = Encoding.UTF8;
			Console.OutputEncoding = Encoding.UTF8;

			Console.BufferHeight = Console.WindowHeight = 46;
			Console.BufferWidth = Console.WindowWidth = 130;

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
		public struct Coordinates
		{
			public int Row, Col;

			public Coordinates(int row, int col)
			{
				this.Row = row;
				this.Col = col;
			}
		}
	}
}
