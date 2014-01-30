using System;

class Variations
{
	static void VariationsGen(int[] array, int index, int N)
	{
		if (array.Length == index)
		{
			PrintVar(array);
		}
		else
		{
			for (int i = 1; i < N + 1; i++)
			{
				array[index] = i;
				VariationsGen(array, index + 1, N);
			}
		}
	}
	static void PrintVar(int[] array)
	{
		for (int i = 0; i < array.Length; i++)
		{
			Console.Write("{0} ", array[i]);
		}
		Console.WriteLine();
	}
	static void Main()
	{
		int N = 3;
		int K = 2;
		int[] vars = new int[K];
		VariationsGen(vars, 0, N);
	}
}