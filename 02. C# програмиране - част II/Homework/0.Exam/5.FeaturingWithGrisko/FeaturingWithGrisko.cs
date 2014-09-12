using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class FeaturingWithGrisko
{
	public static int counter = 0;
	public static int index;
	static void Main()
	{
		string input = Console.ReadLine();
		char[] letters = new char[input.Length];
		for (int i = 0; i < input.Length; i++)
		{
			letters[i] = input[i];
		}

		index = letters.Length;

		new PermutationFinder<char>().Evaluate(letters,Evaluate);
		Console.WriteLine(counter);
	}
	static bool IsValidWord(char[] letters)
    {
        for (int i = 0; i < letters.Length - 1; i++)
            if (letters[i] == letters[i + 1])
                return false;

        return true;
    }
	private static bool Evaluate(char[] letters)
	{
		if(index==letters.Length)
		{
			if (IsValidWord(letters))
				counter++;
			return false;
		}

		//counter++;
		return false;
	}

	
}



public class PermutationFinder<T>
{
	private T[] items;
	private Predicate<T[]> SuccessFunc;
	private bool success = false;
	private int itemsCount;

	public void Evaluate(T[] items, Predicate<T[]> SuccessFunc)
	{
		this.items = items;
		this.SuccessFunc = SuccessFunc;
		this.itemsCount = items.Count();

		Recurse(0);
	}

	private void Recurse(int index)
	{
		T tmp;

		if (index == itemsCount)
			success = SuccessFunc(items);
		else
		{
			for (int i = index; i < itemsCount; i++)
			{
				tmp = items[index];
				items[index] = items[i];
				items[i] = tmp;

				Recurse(index + 1);

				if (success)
					break;

				tmp = items[index];
				items[index] = items[i];
				items[i] = tmp;
			}
		}
	}
}