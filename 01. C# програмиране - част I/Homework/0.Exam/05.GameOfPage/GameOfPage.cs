using System;
class GameOfPage
{
	static bool isCookie(int row,int col,int[,] matrix)
	{
		if (row > 0 && row < 15 && col > 0 && col < 15)
		{
			//check for cookie
			int count = 0;
			for (int i = row - 1; i <= row + 1; i++)
			{
				for (int j = col - 1; j <= col + 1; j++)
				{
					if (matrix[i, j] == 1)
					{
						count++;
					}
				}
			}
			if (count == 9)
			{
				return true;

			}
			else
			{
				return false;

			}
		}
		else
		{
			return false;
		}
	}
	static bool isCrump(int row,int col,int[,] matrix)
	{
		if (row > 0 && row < 15 && col > 0 && col < 15)
		{
			int count = 0;
			for (int i = row - 1; i <= row + 1; i++)
			{
				for (int j = col - 1; j <= col + 1; j++)
				{
					if (matrix[i, j] == 1)
					{
						count++;
					}
				}
			}
			if ((count == 1) && matrix[row, col] == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (row == 0 && col == 0)
		{
			int count = 0;
			for (int i = row; i <= row + 1; i++)
			{
				for (int j = col; j <= col + 1; j++)
				{
					if (matrix[i, j] == 1)
					{
						count++;
					}
				}
			}
			if ((count == 1) && matrix[row, col] == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if(row==15 && col==15)
		{
			int count = 0;
			for (int i = row - 1; i <= row; i++)
			{
				for (int j = col - 1; j <= col; j++)
				{
					if (matrix[i, j] == 1)
					{
						count++;
					}
				}
			}
			if ((count == 1) && matrix[row, col] == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if(row==0 && col==15)
		{
			int count = 0;
			for (int i = row ; i <= row + 1; i++)
			{
				for (int j = col - 1; j <= col; j++)
				{
					if (matrix[i, j] == 1)
					{
						count++;
					}
				}
			}
			if ((count == 1) && matrix[row, col] == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if(row==15 & col==0)
		{
			int count = 0;
			for (int i = row - 1; i <= row ; i++)
			{
				for (int j = col; j <= col + 1; j++)
				{
					if (matrix[i, j] == 1)
					{
						count++;
					}
				}
			}
			if ((count == 1) && matrix[row, col] == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if(row==0)
		{
			int count = 0;
			for (int i = row ; i <= row + 1; i++)
			{
				for (int j = col - 1; j <= col + 1; j++)
				{
					if (matrix[i, j] == 1)
					{
						count++;
					}
				}
			}
			if ((count == 1) && matrix[row, col] == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if(col==0)
		{
			int count = 0;
			for (int i = row - 1; i <= row + 1; i++)
			{
				for (int j = col ; j <= col + 1; j++)
				{
					if (matrix[i, j] == 1)
					{
						count++;
					}
				}
			}
			if ((count == 1) && matrix[row, col] == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if(row==15)
		{
			int count = 0;
			for (int i = row - 1; i <= row ; i++)
			{
				for (int j = col - 1; j <= col + 1; j++)
				{
					if (matrix[i, j] == 1)
					{
						count++;
					}
				}
			}
			if ((count == 1) && matrix[row, col] == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else if (col==15)
		{
			int count = 0;
			for (int i = row - 1; i <= row + 1; i++)
			{
				for (int j = col - 1; j <= col; j++)
				{
					if (matrix[i, j] == 1)
					{
						count++;
					}
				}
			}
			if ((count == 1) && matrix[row, col] == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else
		{
			return false;
		}
	} 
	static bool isBrokenCookie(int row,int col,int[,] matrix)
	{
		if (row > 0 && row < 15 && col > 0 && col < 15)
		{
			int count = 0;
			for (int i = row - 1; i <= row + 1; i++)
			{
				for (int j = col - 1; j <= col + 1; j++)
				{
					if (matrix[i, j] == 1)
					{
						count++;
					}
				}
			}
			if (count < 9 && (matrix[row, col] == 1))
			{
				return true;

			}
			else
			{
				return false;

			}
		}
		else if(row==0 && col==0)
		{
			int count = 0;
			for (int i = row ; i <= row + 1; i++)
			{
				for (int j = col ; j <= col + 1; j++)
				{
					if (matrix[i, j] == 1)
					{
						count++;
					}
				}
			}
			if (count < 9 && (matrix[row, col] == 1))
			{
				return true;

			}
			else
			{
				return false;

			}
		}
		else if(row==15 && col==15)
		{
			int count = 0;
			for (int i = row - 1; i <= row ; i++)
			{
				for (int j = col - 1; j <= col ; j++)
				{
					if (matrix[i, j] == 1)
					{
						count++;
					}
				}
			}
			if (count < 9 && (matrix[row, col] == 1))
			{
				return true;

			}
			else
			{
				return false;

			}
		}
		else if(row==0 && col==15)
		{
			int count = 0;
			for (int i = row ; i <= row + 1; i++)
			{
				for (int j = col - 1; j <= col ; j++)
				{
					if (matrix[i, j] == 1)
					{
						count++;
					}
				}
			}
			if (count < 9 && (matrix[row, col] == 1))
			{
				return true;

			}
			else
			{
				return false;

			}
		}
		else if(row==15 && col==0)
		{
			int count = 0;
			for (int i = row - 1; i <= row ; i++)
			{
				for (int j = col ; j <= col + 1; j++)
				{
					if (matrix[i, j] == 1)
					{
						count++;
					}
				}
			}
			if (count < 9 && (matrix[row, col] == 1))
			{
				return true;

			}
			else
			{
				return false;

			}
		}
		else if(row==0)
		{
			int count = 0;
			for (int i = row; i <= row + 1; i++)
			{
				for (int j = col - 1; j <= col + 1; j++)
				{
					if (matrix[i, j] == 1)
					{
						count++;
					}
				}
			}
			if (count < 9 && (matrix[row, col] == 1))
			{
				return true;

			}
			else
			{
				return false;

			}
		}
		else if(col==0)
		{
			int count = 0;
			for (int i = row - 1; i <= row + 1; i++)
			{
				for (int j = col; j <= col + 1; j++)
				{
					if (matrix[i, j] == 1)
					{
						count++;
					}
				}
			}
			if (count < 9 && (matrix[row, col] == 1))
			{
				return true;

			}
			else
			{
				return false;

			}
		}
		else if(row == 15)
		{
			int count = 0;
			for (int i = row - 1; i <= row ; i++)
			{
				for (int j = col - 1; j <= col + 1; j++)
				{
					if (matrix[i, j] == 1)
					{
						count++;
					}
				}
			}
			if (count < 9 && (matrix[row, col] == 1))
			{
				return true;

			}
			else
			{
				return false;

			}
		}
		else if(col==15)
		{
			int count = 0;
			for (int i = row - 1; i <= row + 1; i++)
			{
				for (int j = col - 1; j <= col; j++)
				{
					if (matrix[i, j] == 1)
					{
						count++;
					}
				}
			}
			if (count < 9 && (matrix[row, col] == 1))
			{
				return true;

			}
			else
			{
				return false;

			}
		}
		else
		{
			return false;
		}
	} 
	static void removeCookie(int row,int col,int[,] matrix)
	{
		for (int i = row - 1; i <= row + 1; i++)
		{
			for (int j = col - 1; j <= col + 1; j++)
			{
				matrix[i, j] = 0;	
			}
		}
	}

	static void Main()
	{
		int listLenght = 16;
		int[,] matrix = new int[listLenght, listLenght];
		for (int i = 0; i < listLenght; i++)
		{
			string readList = Console.ReadLine();
			for (int j = 0; j < listLenght; j++)
			{
				if(readList[j]=='0')
				{
					matrix[i, j] = 0;
				}
				else
				{
					matrix[i, j] = 1;
				}
			}
		}
		string command = Console.ReadLine();
		double sum = 0;
		while (command!="paypal")
		{
			if (command=="what is")
			{
				int row = int.Parse(Console.ReadLine());
				int col = int.Parse(Console.ReadLine());
				
				//output
				if (isCookie(row, col, matrix))
				{
					Console.WriteLine("cookie");
				}
				else if(isCrump(row,col,matrix))
				{
					Console.WriteLine("cookie crumb");
				}
				else if(isBrokenCookie(row,col,matrix))
				{
					Console.WriteLine("broken cookie");
				}
				else
				{
					Console.WriteLine("smile");
				}
				
			}
			else if(command=="buy")
			{
				int row = int.Parse(Console.ReadLine());
				int col = int.Parse(Console.ReadLine());

				if (isCookie(row, col, matrix))
				{
					sum += 1.79;
					//remove cookie
					removeCookie(row, col, matrix);
				}
				else if (isCrump(row, col, matrix))
				{
					Console.WriteLine("page");
				}
				else if (isBrokenCookie(row, col, matrix))
				{
					Console.WriteLine("page");
				}
				else
				{
					Console.WriteLine("smile");
				}
			}
			command = Console.ReadLine();
		}

		//paypal
		Console.WriteLine("{0:0.00}",sum);

	}
}

