using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Tron3D
{
	static int oldX, oldY, oldZ;

	struct Field
	{
		public int X, Y;
		public bool[,] matrix;

		public Field(int x, int y, bool[,] matrix)
		{
			this.X = x;
			this.Y = y;
			this.matrix = matrix;
		}
	}
	struct Player
	{
		public int X;
		public int oldX;
		public int startX;
		public int startY;
		public int Y;
		public int oldY;
		public int Index;
		public string Moves;
		public bool Losses;
		public Directions Direction;
		public int distanction;

		public Player(int x, int oldX, int startX, int y, int oldY, int startY, string moves, Directions direction, bool Losses, int distanction, int index = 0)
		{
			this.X = x;
			this.oldX = oldX;
			this.startX = startX;
			this.startY = startY;
			this.oldY = oldY;
			this.Y = y;
			this.Moves = moves;
			this.Direction = direction;
			this.Losses = Losses;
			this.Index = index;
			this.distanction = distanction;
		}
	}
	static Player RedPlayer = new Player();
	static Player BluePlayer = new Player();
	static Field gameField = new Field();
	public enum Directions { right, down, left, up };

	static void ReadInput()
	{
		string xyzAsAString = Console.ReadLine();
		string[] xyzArray = xyzAsAString.Split(' ');
		oldX = int.Parse(xyzArray[0]);
		oldY = int.Parse(xyzArray[1]);
		oldZ = int.Parse(xyzArray[2]);

		RedPlayer.Moves = Console.ReadLine();
		BluePlayer.Moves = Console.ReadLine();
	}

	static void InitializePlayers()
	{
		//creating the matrix
		gameField.X = oldX;
		gameField.Y = 2 * oldY + 2 * oldZ;
		gameField.matrix = new bool[gameField.X + 1, gameField.Y];

		//starting points of players
		RedPlayer.X = oldX / 2;
		RedPlayer.Y = oldY / 2;
		RedPlayer.startX = RedPlayer.X;
		RedPlayer.startY = RedPlayer.Y;
		RedPlayer.Direction = Directions.right; //red player starts to the right

		BluePlayer.X = oldX / 2;
		BluePlayer.Y = oldY + oldZ + oldY / 2;
		BluePlayer.startX = BluePlayer.X;
		BluePlayer.startY = BluePlayer.Y;
		BluePlayer.Direction = Directions.left; //blue starts to the left
	}

	static void RotateLeft(ref Player player)
	{
		//player.Direction = player.Direction - 1;
		if (player.Direction == Directions.right)
		{
			player.Direction = Directions.up;
		}
		else if (player.Direction == Directions.up)
		{
			player.Direction = Directions.left;
		}
		else if (player.Direction == Directions.left)
		{
			player.Direction = Directions.down;
		}
		else if (player.Direction == Directions.down)
		{
			player.Direction = Directions.right;
		}
	}

	static void RotateRight(ref Player player)
	{
		//player.Direction = player.Direction + 1;
		if (player.Direction == Directions.right)
		{
			player.Direction = Directions.down;
		}
		else if (player.Direction == Directions.up)
		{
			player.Direction = Directions.right;
		}
		else if (player.Direction == Directions.left)
		{
			player.Direction = Directions.up;
		}
		else if (player.Direction == Directions.down)
		{
			player.Direction = Directions.left;
		}
	}

	static void MovePlayer(ref Player player)
	{
		if (player.Direction == Directions.right)
		{
			player.Y++;
		}
		else if (player.Direction == Directions.up)
		{
			player.X--;
		}
		else if (player.Direction == Directions.left)
		{
			player.Y--;
		}
		else if (player.Direction == Directions.down)
		{
			player.X++;
		}
	}

	static bool Losses(Player player)
	{
		if (player.X < 0)
		{
			return true;
		}
		if (player.X > gameField.X)
		{
			return true;
		}
		if (gameField.matrix[player.X, player.Y])
		{
			return true;
		}
		return false;
	}

	static void FixYCoord(ref Player player)
	{
		if (player.Y >= gameField.Y)
		{
			player.Y = 0;
		}
		if (player.Y < 0)
		{
			player.Y = gameField.Y - 1;
		}
	}

	static void Main()
	{

		ReadInput();
		InitializePlayers();


		while (true)
		{
			#region Move redPlayer
			while (RedPlayer.Index < RedPlayer.Moves.Length && RedPlayer.Moves[RedPlayer.Index] != 'M')
			{
				//TODO: save old coordinates of players
				RedPlayer.oldX = RedPlayer.X;
				RedPlayer.oldY = RedPlayer.Y;

				if (RedPlayer.Moves[RedPlayer.Index] == 'L')
				{
					RotateLeft(ref RedPlayer);
				}
				else
				{
					RotateRight(ref RedPlayer);
				}
				RedPlayer.Index++;
			}
			//move
			MovePlayer(ref RedPlayer);
			RedPlayer.Index++;
			#endregion

			#region Move bluePlayer
			//blue player
			while (BluePlayer.Index<BluePlayer.Moves.Length && BluePlayer.Moves[BluePlayer.Index] != 'M')
			{
				//TODO: save old coordinates of players
				BluePlayer.oldX = BluePlayer.X;
				BluePlayer.oldY = BluePlayer.Y;

				if (BluePlayer.Moves[BluePlayer.Index] == 'L')
				{
					RotateLeft(ref BluePlayer);
				}
				else
				{
					RotateRight(ref BluePlayer);
				}
				BluePlayer.Index++;
			}
			//move
			MovePlayer(ref BluePlayer);
			BluePlayer.Index++;
			#endregion

			#region Fix y coords (loops)
			FixYCoord(ref RedPlayer);
			FixYCoord(ref BluePlayer);
			#endregion

			#region check if players losse
			//check if players losse
			RedPlayer.Losses = Losses(RedPlayer);
			BluePlayer.Losses = Losses(BluePlayer);
			//return who losses 
			if (RedPlayer.Losses && BluePlayer.Losses)
			{
				Console.WriteLine("DRAW");
			}
			else if (RedPlayer.Losses)
			{
				Console.WriteLine("BLUE");
			}
			else if (BluePlayer.Losses)
			{
				Console.WriteLine("RED");
			}
			#endregion

			


			if (RedPlayer.Losses || BluePlayer.Losses)
			{
				//int diffRedLeft = RedPlayer.startY + (gameField.Y - RedPlayer.Y);
				int diffRedRight = Math.Abs(RedPlayer.Y - RedPlayer.startY);
				

				if(RedPlayer.Y > BluePlayer.startY)
				{
					diffRedRight = RedPlayer.Y - BluePlayer.startY;
				}

				RedPlayer.distanction = Math.Abs(RedPlayer.X - RedPlayer.startX) + diffRedRight;

				if (RedPlayer.Losses && BluePlayer.Losses)
				{
					Console.WriteLine(RedPlayer.distanction - 1);
				}
				else
				{
					Console.WriteLine(RedPlayer.distanction);
					
				}
				break;
			}

			//mark as used
			gameField.matrix[RedPlayer.X, RedPlayer.Y] = true;
			gameField.matrix[BluePlayer.X, BluePlayer.Y] = true;
		}
	}
}

