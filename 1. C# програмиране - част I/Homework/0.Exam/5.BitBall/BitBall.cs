using System;
class BitBall
{
	static void Main()
	{
		int n = 8;
		int[,] matrix = new int[n, n];

		//read the first team
		for (int i = 0; i < n; i++)
		{
			int number = int.Parse(Console.ReadLine());
			for (int j = 0; j < n; j++)
			{
				int bit = (number >> j) & 1;
				if(bit==1)
				{
					matrix[i, j] = 1;
				}
			}
		}

		//read the second team
		for (int i = 0; i < n; i++)
		{
			int number = int.Parse(Console.ReadLine());
			for (int j = 0; j < n; j++)
			{
				int bit = (number >> j) & 1;
				if(bit==1)
				{
					if (matrix[i,j]==1)
					{
						matrix[i, j] = 0;
					}
					else
					{
						matrix[i, j] = 2;
					}
				}
			}
		}
		//the score
		int score1 = 0;
		int score2 = 0;

		//check the col for second team
		for (int col = 0; col < n; col++)
		{
			for (int row = 0; row < n; row++)
			{
				if (matrix[row,col]==2)
				{
					score2++;
					break;
				}
				else if(matrix[row,col]==1)
				{
					break;
				}
			}
		}

		//check the col for first team
		for (int col = 0; col < n; col++)
		{
			for (int row = n-1; row >= 0; row--)
			{
				if(matrix[row,col]==1)
				{
					score1++;
					break;
				}
				else if(matrix[row,col]==2)
				{
					break;
				}
			}
		}

		Console.WriteLine("{0}:{1}",score1,score2);
	}
}

