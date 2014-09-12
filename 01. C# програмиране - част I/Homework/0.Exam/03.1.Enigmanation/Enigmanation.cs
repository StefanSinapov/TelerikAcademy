using System;
class Enigmanation
{
	static string SUM(decimal a,decimal b)
	{
		string SUM = (a + b).ToString();
		return SUM;
	}
	static string SUBTRACT(decimal a,decimal b)
	{
		string SUBTRACT = (a - b).ToString();
		return SUBTRACT;
	}
	static string MULTIPLY(decimal a,decimal b)
	{
		string MULTIPLY = (a * b).ToString();
		return MULTIPLY;
	}
	static string MODULE(decimal a,decimal b)
	{
		string MODULE = (a % b).ToString();
		return MODULE;
	}

	static void Main()
	{
		string equation = Console.ReadLine();
		int i = 0;
		
		decimal b;
		decimal previousNumber = decimal.Parse(equation[0].ToString());
		while (equation[i] != '=')
		{
			switch (equation[i])
			{
				case '+':
					//a = int.Parse(equation[i - 1].ToString());
					b = int.Parse(equation[i + 1].ToString());
					equation=SUM(previousNumber,b)+equation;
					equation = equation.Remove(SUM(previousNumber,b).Length, SUM(previousNumber,b).Length+i);
					previousNumber = int.Parse(SUM(previousNumber, b));
					i = 0;
					break;
				case '-':
					//a = int.Parse(equation[i - 1].ToString());
					b = int.Parse(equation[i + 1].ToString());
					equation=SUBTRACT(previousNumber,b)+equation;
					equation = equation.Remove(SUBTRACT(previousNumber,b).Length, SUBTRACT(previousNumber,b).Length+i);
					previousNumber = int.Parse(SUBTRACT(previousNumber, b));
					i = 0;
					break;
				case '*':
					b = int.Parse(equation[i + 1].ToString());
					equation=MULTIPLY(previousNumber,b)+equation;
					equation = equation.Remove(MULTIPLY(previousNumber,b).Length, MULTIPLY(previousNumber,b).Length+i);
					previousNumber = int.Parse(MULTIPLY(previousNumber, b));
					i = 0;
					break;
				case '%':
					b = int.Parse(equation[i + 1].ToString());
					equation=MODULE(previousNumber,b)+equation;
					equation = equation.Remove(MODULE(previousNumber,b).Length, MODULE(previousNumber,b).Length+i);
					previousNumber = int.Parse(MODULE(previousNumber, b));
					i = 0;
					break;
				default:
					break;
			}
			i++;
		} 

		Console.WriteLine("{0:0.000}",equation.Remove(equation.Length-1,1));
	}
}

