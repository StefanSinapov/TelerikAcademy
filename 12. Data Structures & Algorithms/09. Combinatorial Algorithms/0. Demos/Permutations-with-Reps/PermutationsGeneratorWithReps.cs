using System;

class PermutationsGeneratorWithReps
{
	static void Main()
	{
		var arr = new int[] { 3, 5, 1, 5, 5 };
		Array.Sort(arr);
		PermuteRep(arr, 0, arr.Length);
	}

	static void PermuteRep(int[] arr, int start, int n)
	{
		Print(arr);

		for (int left = n - 2; left >= start; left--)
		{
			for (int right = left + 1; right < n; right++)
			{
				if (arr[left] != arr[right])
				{
					Swap(ref arr[left], ref arr[right]);
					PermuteRep(arr, left + 1, n);
				}
			}

			// Undo all modifications done by the
			// previous recursive calls and swaps
			var firstElement = arr[left];
			for (int i = left; i < n - 1; i++)
			{
				arr[i] = arr[i + 1];
			}
			arr[n - 1] = firstElement;
		}
	}

	static void Print<T>(T[] arr)
	{
		Console.WriteLine(string.Join(", ", arr));
	}

	static void Swap<T>(ref T first, ref T second)
	{
		T oldFirst = first;
		first = second;
		second = oldFirst;
	}
}
