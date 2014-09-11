using System;

class VariationsGeneratorNoReps
{
	const int n = 10;
	const int k = 3;
	static string[] objects = new string[n] 
	{
		"banana", "apple", "orange", "strawberry", "raspberry",
		"apricot", "cherry", "lemon", "grapes", "melon"
	};
	static int[] arr = new int[k];
	static bool[] used = new bool[n];

	static void Main()
	{
		GenerateVariationsNoRepetitions(0);
	}

	static void GenerateVariationsNoRepetitions(int index)
	{
		if (index >= k)
		{
			PrintVariations();
		}
		else
		{
			for (int i = 0; i < n; i++)
			{
				if (!used[i])
				{
					used[i] = true;
					arr[index] = i;
					GenerateVariationsNoRepetitions(index + 1);
					used[i] = false;
				}
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
