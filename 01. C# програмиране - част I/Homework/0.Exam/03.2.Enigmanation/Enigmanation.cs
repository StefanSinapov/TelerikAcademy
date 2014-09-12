//using System;
//class Program
//{
//	static void Main(string[] args)
//	{
//		string equation = Console.ReadLine();
//		int[] numbers = new int[equation.Length];
//		char[] signs=new char[equation.Length];
//		for (int i = 0; i < equation.Length; i++)
//		{
//			switch (equation[i])
//			{
//				case '1': numbers[i] = 1;
//					break;
//				case '2': numbers[i] = 2;
//					break;
//				case '3': numbers[i] = 3;
//					break;
//				case '4': numbers[i] = 4;
//					break;
//				case '5': numbers[i] = 5;
//					break;
//				case '6': numbers[i] = 6;
//					break;
//				case '7': numbers[i] = 7;
//					break;
//				case '8': numbers[i] = 8;
//					break;
//				case '9': numbers[i] = 9;
//					break;
//				case '0': numbers[i] = 0;
//					break;
//				case '+': signs[i] = '+';
//					break;
//				case '-': signs[i] = '-';
//					break;
//				case '*': signs[i] = '*';
//					break;
//				case '%': signs[i] = '%';
//					break;
//				case '=': signs[i] = '=';
//					break;
//				default:
//					break;
//			}
//		}
//		decimal sum = numbers[0];
//		for (int i = 0; i < equation.Length; i++)
//		{
//			bool isEqual = false;
//			switch (signs[i])
//			{
//				case '+':
//					sum += numbers[i + 1];
//					break;
//				case '-':
//					sum -= numbers[i + 1];
//					break;
//				case '*':
//					sum *= numbers[i + 1];
//					break;
//				case '%':
//					sum %= numbers[i + 1];
//					break;
//				case '=': isEqual = true;
//					break;
//				default:
//					break;
//			}
//			if (isEqual)
//			{
//				break;
//			}
//		}
//		Console.WriteLine("{0:0.000}",sum);
//	}
//}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigmanation.TestGenerator
{
	class EnigmanationSolution
	{
		static void Main()
		{
			int symbol = Console.Read();
			decimal sum = 0;
			int o = '+';

			while (symbol != '=')
			{
				if (symbol == '(')
				{
					decimal innerSum = 0;
					int innerO = '+';
					symbol = Console.Read();

					while (symbol != ')')
					{
						if (0 <= symbol - '0' && symbol - '0' <= 9)
						{
							switch (innerO)
							{
								case '+':
									innerSum += symbol - '0';
									break;
								case '-':
									innerSum -= symbol - '0';
									break;
								case '*':
									innerSum *= symbol - '0';
									break;
								case '%':
									innerSum %= symbol - '0';
									break;
							}
						}
						else if (symbol == '+' ||
								 symbol == '-' ||
								 symbol == '%' ||
								 symbol == '*')
						{
							innerO = symbol;
						}
						symbol = Console.Read();
					}

					switch (o)
					{
						case '+':
							sum += innerSum;
							break;
						case '-':
							sum -= innerSum;
							break;
						case '*':
							sum *= innerSum;
							break;
						case '%':
							sum %= innerSum;
							break;
					}
				}
				else if (0 <= symbol - '0' && symbol - '0' <= 9)
				{
					switch (o)
					{
						case '+':
							sum += symbol - '0';
							break;
						case '-':
							sum -= symbol - '0';
							break;
						case '*':
							sum *= symbol - '0';
							break;
						case '%':
							sum %= symbol - '0';
							break;
					}
				}
				else if (symbol == '+' ||
						 symbol == '-' ||
						 symbol == '*' ||
						 symbol == '%')
				{
					o = symbol;
				}
				symbol = Console.Read();
			}

			Console.WriteLine("{0:0.000}", sum);
		}

	}
}
