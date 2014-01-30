using System;
using System.Text;
class Enigmanation
{
	static void Main()
	{
		string equation = Console.ReadLine();
		decimal sum = 0m;
		char sign=' ';
		bool bracket = false;
		bool havePreveousNumber = false;
		bool haveSign = false;
		decimal previousNumber=0m;
		bool isSign = false;

		for (int i = 0; i < equation.Length; i++)
		{
			int number;
			bool isNumber = int.TryParse(equation[i].ToString(), out number);
			if(equation[i]=='(')
			{
				bracket = true;
			}
			else if(equation[i]==')')
			{
				bracket=false;
			}
			else if(isNumber)
			{
				if (!havePreveousNumber)
				{
					previousNumber = number;
					havePreveousNumber = true;
				}
				isSign = false;
			}
			else
			{
				sign = equation[i];
				isSign = true;
				haveSign = true;
				
			}


			

			//solve in brackets 
			if(bracket)
			{

			}
			else if (isNumber && haveSign && havePreveousNumber) //simpole calculation
			{
				if(haveSign && havePreveousNumber)
				{
					switch (sign)
					{
						case '+': sum += (previousNumber + number);
							break;
						case '-': sum += (previousNumber - number);
							break;
						case '*': sum += (previousNumber * number);
							break;
						case '%': sum += (previousNumber % number);
							break;
						default:
							break;
					}
					isSign = false;
					previousNumber = 0;///!!!!
					equation = sum.ToString() + equation;
					haveSign = false;
					havePreveousNumber = false;
				}
			}

			if(equation[i]=='=')
			{
				break;
			}
			
		}
		
		//output
		Console.WriteLine("{0:0.000}",sum);
	}
}

