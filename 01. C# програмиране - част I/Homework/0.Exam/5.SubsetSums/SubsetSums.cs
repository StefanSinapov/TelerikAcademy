using System;

class SubsetSums
{
	static void Main()
	{
		long s = long.Parse(Console.ReadLine());
		int n = int.Parse(Console.ReadLine());
		long[] set = new long[n];

		//read the numbers
		for (int i = 0; i < n; i++)
		{
			set[i] = long.Parse(Console.ReadLine());
		}

		//all posible combinations of N numbers are 2^n
		/*
		 * всяка възможна комбинация е като от първата до броя представени в двоичен вид
		 */
		int counter = 0;
		for (int i = 1; i < Math.Pow(2,n); i++)
		{
			
			string combination = Convert.ToString(i, 2).PadLeft(n, '0');
			long currentSum = 0;
			for (int j = 0; j < combination.Length; j++)
			{
				if (combination[j]=='1')
				{
					currentSum = currentSum + set[j];
				}
			}
			if(currentSum==s)
			{
				counter++;
			}

		}
		Console.WriteLine(counter);
	}
}


		/*
		int counter=0;
		Array.Sort(set);
		Array.Reverse(set);
		
		// my logic    40 / 100
		for (int i = 0; i < n; i++)
		{
			for (int j = i; j < n; j++)
			{
				BigInteger sum = 0;
				for (int sub = i; sub < n; sub++)
				{
					sum += set[sub];
				}
				if(sum==s)
				{
					counter++;
				}
				sum = 0;
			}
		}
		*/



		/*bitwise
		 * int maxI = 1;
        for (int i = 1; i <= n; i++)
        {
            maxI *= 2;
        }
        maxI -= 1;
        int count = 0;
        for (int i = 1; i <= maxI; i++)
        {
            long currentSum = 0;
            for (int j = 0; j < n; j++)
            {
                int mask = 1 << j;
                int nAndMask = i & mask;
                int bit = nAndMask >> j;
                if (bit == 1)
                {
                    currentSum+=nums[j];
                }
            }
            if (currentSum == s)
            {
                count++;
            }
        }
        Console.WriteLine(count);
		 */  


		



