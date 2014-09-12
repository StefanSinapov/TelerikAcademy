using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class HelpDoge
{
	//static char[,] lab =
	//{
	//	{ ' ', ' ', ' ', ' ', ' ' },
	//	{ ' ', '*', ' ', ' ', ' ' },
	//	{ ' ', ' ', '*', '*', ' ' },
	//	{ ' ', ' ', ' ', ' ', 'e' }
	//};

	static char[,] field;
	static int fX;
	static int fY;
	static int counter;
	struct Enemy
	{
		public int X;
		public int Y;
		public Enemy(int x,int y)
		{
			this.X = x;
			this.Y = y;
		}
	}

	static List<Enemy> enemies = new List<Enemy>();

	static void FindExit(int row, int col)
	{
		if (/*(col < 0) || (row < 0) ||*/ (col >= field.GetLength(1) || (row >= field.GetLength(0))))
		{
			//We are out of the labyrinth -> can't find a path
			return;
		}

		//Check if we have found the exit
		if (field[row, col] == 'e')
		{
			//Console.WriteLine("Found the exit!");
			counter++;
		}

		if (field[row, col] == ' ')
		{
			//Temporary mark the current cell as visited
			field[row, col] = 's';

			//Invoke recursion to explore all possible directions
			//FindExit(row, col - 1); //left
			//FindExit(row - 1, col); //up
			FindExit(row, col + 1); //right
			FindExit(row + 1, col); //down

			//Mark back the current cell as free
			field[row, col] = ' '; // <--
		}
	}


	static void Main()
	{

		ReadInput();

		//draw field
		DrawField();

		FindExit(0, 0);

		//print counter
		Console.WriteLine(counter);
	}

	private static void DrawField()
	{
		for (int i = 0; i < field.GetLength(0); i++)
		{
			for (int j = 0; j < field.GetLength(1); j++)
			{
				field[i, j] = ' ';
			}
		}

		foreach(Enemy enemy in enemies)
		{
			field[enemy.X, enemy.Y] = '*';
		}

		field[fX, fY] = 'e';
	}

	private static void ReadInput()
	{
		string[] nAndM = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		field = new char[int.Parse(nAndM[0].ToString()), int.Parse(nAndM[1].ToString())];

		string[] exit = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		fX = int.Parse(exit[0]);
		fY = int.Parse(exit[1]);

		//enemies
		int k = int.Parse(Console.ReadLine());
		for (int i = 0; i < k; i++)
		{
			string[] coords = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			enemies.Add(new Enemy(int.Parse(coords[0].ToString()), int.Parse(coords[1].ToString())));
		}
	}
}

