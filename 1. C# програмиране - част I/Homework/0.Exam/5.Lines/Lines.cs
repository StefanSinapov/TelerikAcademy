using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Lines
{
	class Lines
	{
		static void Main()
		{
			int[,] matrix = new int[8, 8];
			byte[] n = new byte[8];

			/*
			//test variables
			n[0]= 8;
			n[1] = 72;
			n[2] = 8;
			n[3] = 8;
			n[4] = 16;
			n[5] = 28;
			n[6] = 240;
			n[7] = 0;
			*/
			
			//read numbers from console
			for (int i = 0; i < 8; i++)
			{
				n[i] = byte.Parse(Console.ReadLine());
			}
			 
			
			
			//draw the matrix with 1 and 0 
			string bufferString;
			for (int i = 0; i < 8; i++)
			{

				bufferString = Convert.ToString(n[i], 2);
				if(bufferString.Length<8)
				{
					int strLength = bufferString.Length;
					for (int z = 0; z < (8-strLength); z++)
					{
						bufferString = "0" + bufferString;
					}
				}
				for (int j = 0; j < 8; j++)
				{
					matrix[i, j] = (int)Char.GetNumericValue(bufferString[j]);
				}
			}


			//check the matrix
			int length = 1;
			int maxLenght = 0;
			int count = 0;
			
			//chack rows
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 7; j++)
				{
					if (matrix[i,j]==matrix[i,j+1] && matrix[i,j]==1)
					{
						length += 1;
					}
				}
				if (length>=maxLenght && length>=1)
				{
					if (maxLenght < length)
					{
						count = 0;
						count++;
					}
					else
					{
						count++;
					}
					maxLenght = length;
				

				}
				length = 1;
			}

			//check cows
			for (int j = 0; j < 8; j++)
			{
				for (int i = 0; i < 7; i++)
				{
					if (matrix[i,j]==matrix[i+1,j] && matrix[i,j]==1)
					{
						length += 1;
					}
				}
				if (length>=maxLenght && length>=1)
				{
					if (maxLenght < length)
					{
						count = 0;
						count++;
					}
					else
					{
						count++;
					}
					maxLenght = length;
					
				}
				length = 1;
			}

			Console.WriteLine(maxLenght);
			Console.WriteLine(count);
			

			//give me only 70 points :(
		}
	}
}
