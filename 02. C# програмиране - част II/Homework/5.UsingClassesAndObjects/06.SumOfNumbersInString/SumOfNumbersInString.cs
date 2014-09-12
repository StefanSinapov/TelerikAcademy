using System;
class SumOfNumbersInString
{
	static void Main()
	{
		Console.Write("Please enter numbers with spaces: ");
		string str = Console.ReadLine();

		string[] numbers = str.Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);

		int sum = 0;
		for (int i = 0; i < numbers.Length; i++)
		{
			int number = 0;
			sum += int.TryParse(numbers[i], out number) ? number : 0;
		}

		Console.WriteLine("Sum is: {0}", sum);
	}
}

