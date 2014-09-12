using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Trails3D
{

	class Trails3D
	{
		static string ConvertCommand(string path)
		{
			StringBuilder result = new StringBuilder();

			path = path.Replace("M", " M ");
			path = path.Replace("L", " L ");
			path = path.Replace("R", " R ");

			string[] separetedPaths = path.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			string lastNumber = null;
			for (int i = 0; i < separetedPaths.Length; i++)
			{
				if (separetedPaths[i] == "L" || separetedPaths[i] == "R")
				{
					result.Append(separetedPaths[i]);
				}
				else if (separetedPaths[i] == "M")
				{
					if (lastNumber == null)
					{
						result.Append("M");
					}
					else
					{
						int number = int.Parse(lastNumber);
						result.Append('M', number);
						lastNumber = null;
					}
				}
				else
				{
					lastNumber = separetedPaths[i];
				}
			}


			return result.ToString();
		}
		static void Main(string[] args)
		{
			string[] xyz = Console.ReadLine().Split(' ');
			int x = int.Parse(xyz[0]);
			int y = int.Parse(xyz[1]);
			int z = int.Parse(xyz[2]);

			string redCommands = ConvertCommand(Console.ReadLine());
			string blueCommands = ConvertCommand(Console.ReadLine());

			bool[,] field = new bool[y + 1, 2 * (x + z)];

			int redRow = y / 2;
			int redCol = z + x / 2;
			string redDirection = "right";

			int blueRow = y / 2;
			int blueCol = 2 * z + x + (x / 2);
			string blueDirection = "left";

			for (int i = 0; i < redCommands.Length; i++)
			{
				//red
				char currentRedComand = redCommands[i];
				if (currentRedComand == 'R' || currentRedComand == 'R')
				{
					redDirection = ChangeDirection(redDirection, currentRedComand);
				}


				//blue
				char currentBlueComand = blueCommands[i];
				if (currentBlueComand == 'R' || currentBlueComand == 'R')
				{
					blueDirection = ChangeDirection(redDirection, currentBlueComand);
				}
			}
		}

		static string ChangeDirection(string direction, char command)
		{
			switch(direction)
			{
				case "up": 
					if(command=='L') return "left";
					if(command=='R') return "right";
					break;
				case "down":
					if(command=='L') return "right";
					if(command=='R') return "left";
					break;
				case "left": 
					if(command=='L') return "down";
					if(command=='R') return "up";
					break;
				case "right":
					if(command=='L') return "up";
					if(command=='R') return "down";
					break;
				default:
					throw new ArgumentException("direction", "direction is not vallid");
			}


			throw new ArgumentException("direction", "direction is not vallid");
		}
	}
}
