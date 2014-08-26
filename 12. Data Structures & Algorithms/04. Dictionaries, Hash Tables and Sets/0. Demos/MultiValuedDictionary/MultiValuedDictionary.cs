using System;
using System.Collections.Generic;

class MultiValuedDictionary
{
	static Dictionary<string, List<int>> studentGrades = 
		new Dictionary<string, List<int>>();

	private static void AddGrade(string name, int grade)
	{
		if (! studentGrades.ContainsKey(name))
		{
			studentGrades[name] = new List<int>();
		}
		studentGrades[name].Add(grade);
	}

	private static void PrintAllGrades()
	{
		foreach (var studentAndGrade in studentGrades)
		{
			Console.WriteLine(studentAndGrade.Key + ": ");
			foreach (var grade in studentAndGrade.Value)
			{
				Console.WriteLine("\t" + grade);
			}
		}
	}

	static void Main()
	{
		AddGrade("Nakov", 6);
		AddGrade("Nakov", 5);
		AddGrade("Maria", 3);
		AddGrade("Maria", 4);
		AddGrade("Nakov", 6);
		AddGrade("Maria", 3);
		AddGrade("Kiril", 4);

		PrintAllGrades();
	}
}
