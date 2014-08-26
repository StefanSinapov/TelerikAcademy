using System;
using System.Collections.Generic;

class DictionaryExample
{
    static void Main()
    {
        Dictionary<string, int> studentsMarks =
        new Dictionary<string, int>();
        studentsMarks.Add("Ivan", 4);
        studentsMarks.Add("Peter", 6);
        studentsMarks.Add("Maria", 6);
        studentsMarks.Add("George", 5);

        int peterMark = studentsMarks["Peter"];
        Console.WriteLine("Peter's mark: {0}", peterMark);

        Console.WriteLine("Is Peter in the hash table: {0}",
			studentsMarks.ContainsKey("Peter"));

        studentsMarks.Remove("Peter");
        Console.WriteLine("Peter removed.");

        Console.WriteLine("Is Peter in the hash table: {0}",
			studentsMarks.ContainsKey("Peter"));

        Console.WriteLine("Ivan's mark: {0}", studentsMarks["Ivan"]);

        studentsMarks["Ivan"] = 3;
        Console.WriteLine("Ivan's mark changed.");

        // Print all elements of the hash table
        Console.WriteLine("Students and grades:");
        foreach (var studentMark in studentsMarks)
        {
            Console.WriteLine("{0} --> {1}",
				studentMark.Key, studentMark.Value);
        }
    }
}
