/*
 * 2. Write a program to calculate the "Minimum Edit Distance" 
 * (MED) between two words. MED(x, y) is the minimal sum of costs 
 * of edit operations used to transform x to y. Sample costs are given below:
	- cost (replace a letter) = 1
	- cost (delete a letter) = 0.9
	- cost (insert a letter) = 0.8
	- Example:
		- delete 'd':  "developer" -> "eveloper", cost = 0.9
		- insert 'n':  "eveloper" -> "enveloper", cost = 0.8
		- replace 'r' -> 'd':  "enveloper" -> "enveloped", cost = 1
 */


namespace _02.Minimum_Edit_Distance
{
    using System;

    internal class MinimumEdinDistance
    {

        const decimal CostDelete = 0.9m;
        const decimal CostInsert = 0.8m;
        static int CostReplace(int i, int j)
        {
            return Starting[i] == Target[j] ? 0 : 1;
        }


        private const string Starting = "eveloper";
        private const string Target = "enveloper";

        static readonly int Length = Math.Max(Starting.Length, Target.Length);
        static decimal[,] F = new decimal[Length + 1, Length + 1];
        static int n1;
        static int n2;

        static void Main()
        {
            n1 = Starting.Length - 1;
            n2 = Target.Length - 1;
            Console.WriteLine("Minimal distance between two strings: {0}", EditDistance());
            PrintEditOperations(n1, n2);

            Console.WriteLine("\n");
        }

        static decimal EditDistance()
        {
            int i, j;
            for (i = 0; i <= n1; i++)
            {
                F[i, 0] = i * CostDelete;
            }
            for (j = 0; j <= n2; j++)
            {
                F[0, j] = j * CostInsert;
            }

            for (i = 1; i <= n1; i++)
            {
                for (j = 1; j <= n2; j++)
                {
                    decimal replace = F[i - 1, j - 1] + CostReplace(i, j);
                    decimal insert = F[i, j - 1] + CostInsert;
                    decimal delete = F[i - 1, j] + CostDelete;
                    F[i, j] = Min(replace, insert, delete);
                }
            }

            return F[n1, n2];
        }

        static decimal Min(decimal replace, decimal insert, decimal delete)
        {
            decimal smaller = replace < insert ? replace : insert;
            decimal smallest = smaller < delete ? smaller : delete;

            return smallest;
        }

        static void PrintEditOperations(int i, int j)
        {
            if (j == 0)
            {
                for (j = 1; j <= i; j++)
                {
                    Console.Write("Delete({0}) ", j);
                }
            }
            else if (i == 0)
            {
                for (i = 1; i <= j; i++)
                {
                    Console.Write("Insert({0}, {1}) ", i, Target[i]);
                }
            }
            else if (i > 0 && j > 0)
            {
                if (F[i, j] == F[i - 1, j - 1] + CostReplace(i, j))
                {
                    PrintEditOperations(i - 1, j - 1);
                    if (CostReplace(i, j) > 0)
                    {
                        Console.Write("Replace({0},{1}) ", i, Target[j]);
                    }
                }
                else if (F[i, j] == F[i, j - 1] + CostInsert)
                {
                    PrintEditOperations(i, j - 1);
                    Console.Write("Insert({0},{1}) ", i, Target[j]);
                }
                else if (F[i, j] == F[i - 1, j] + CostDelete)
                {
                    PrintEditOperations(i - 1, j);
                    Console.Write("Delete({0}) ", i);
                }
            }
        }
    }
}
