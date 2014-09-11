using System;

class CombinationsGeneratorNoReps
{
	const int n = 5;
	const int k = 3;
	static string[] objects = new string[n] 
	{
		"banana", "apple", "orange", "strawberry", "raspberry"
	};
	static int[] arr = new int[k];

	static void Main()
	{
		GenerateCombinationsNoRepetitions(0, 0);
	}

	static void GenerateCombinationsNoRepetitions(int index, int start)
	{
		if (index >= k)
		{
			PrintVariations();
		}
		else
		{
			for (int i = start; i < n; i++)
			{
				arr[index] = i;
				GenerateCombinationsNoRepetitions(index + 1, i + 1);
			}
		}
	}

	static void PrintVariations()
	{
		Console.Write("(" + String.Join(", ", arr) + ") --> ( ");
		for (int i = 0; i < arr.Length; i++)
		{
			Console.Write(objects[arr[i]] + " ");
		}
		Console.WriteLine(")");
	}
}
