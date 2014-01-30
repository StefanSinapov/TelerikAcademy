/*
 * Write a program that calculates for given N how many trailing zeros present at the end of the number N!.
 * Examples:
	N = 10  N! = 3628800  2
	N = 20  N! = 2432902008176640000  4
	Does your program work for N = 50 000?
	Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5. Think why!
*/
using System;
using System.Numerics;
class TrailingZeros
{
	static void Main(string[] args)
	{
		Console.Write("N= ");
		int n = int.Parse(Console.ReadLine());
		BigInteger factorials=1;
		int counter=0;
		int divider = 5;
		/*
		for (int i = 1; i <= n; i++)
		{
			factorials *= i;
		}
		while ((factorials%10)==0)
		{
			counter++;
			factorials /= 10;
		}
		 */

		while (n / divider >= 1)
		{
			counter += n / divider;
			divider *= 5;
		}
		Console.WriteLine(counter);
	}
}

