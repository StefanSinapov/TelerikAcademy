using System;
using System.Collections.Generic;

class SetsExample
{
    static void Main()
    {
        Console.WriteLine("HashSet<T>");
        Console.WriteLine("----------");
        ISet<string> firstSet = new HashSet<string>() { "Perl", "Java", "C#", "SQL", "PHP" };
        ISet<string> secondSet = new HashSet<string>() { "Oracle", "SQL", "MySQL" };
        DisplayUnionIntersect(firstSet, secondSet);

        Console.WriteLine();
        Console.WriteLine("SortedSet<T>");
        Console.WriteLine("------------");
        firstSet = new SortedSet<string>() { "Perl", "Java", "C#", "PHP", "SQL" };
        secondSet = new SortedSet<string>() { "Oracle", "SQL", "MySQL" };
        DisplayUnionIntersect(firstSet, secondSet);
    }

    private static void DisplayUnionIntersect(ISet<string> firstSet, ISet<string> secondSet)
    {
        Console.Write("First set: ");
        PrintSet(firstSet);

        Console.Write("Second set: ");
        PrintSet(secondSet);

        ISet<string> union = new HashSet<string>(firstSet);
        union.UnionWith(secondSet);
        Console.Write("Union: ");
        PrintSet(union);

        ISet<string> intersect = new HashSet<string>(firstSet);
        intersect.IntersectWith(secondSet);
        Console.Write("Intersect: ");
        PrintSet(intersect);
    }

    private static void PrintSet<T>(ISet<T> set)
    {
        foreach (var element in set)
        {
            Console.Write("{0} ", element);
        }
        Console.WriteLine();
    }
}
