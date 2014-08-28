using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

class PowerCollectionsDemo
{
    static void Main()
    {
        Console.Write("Bag of Integers: ");
        Bag<int> bagOfInts = new Bag<int>();
        bagOfInts.Add(3);
        bagOfInts.Add(5);
        bagOfInts.Add(5);
        bagOfInts.Add(5);
        bagOfInts.Add(10);
        bagOfInts.Add(20);
        bagOfInts.Add(20);
        bagOfInts.Remove(5);
        bagOfInts.RemoveAllCopies(20);
        bagOfInts.UnionWith(new Bag<int>() { 3, 3, 4, 4, 5, 5 });
        Console.WriteLine(bagOfInts);

        Console.Write("OrderedBag of Integers: ");
        OrderedBag<int> orderedBagOfInts = new OrderedBag<int>();
        orderedBagOfInts.Add(3);
        orderedBagOfInts.Add(5);
        orderedBagOfInts.Add(5);
        orderedBagOfInts.Add(5);
        orderedBagOfInts.Add(10);
        orderedBagOfInts.Add(20);
        orderedBagOfInts.Add(20);
        orderedBagOfInts.Remove(5);
        orderedBagOfInts.RemoveAllCopies(20);
        orderedBagOfInts.UnionWith(
            new OrderedBag<int>() { 3, 3, 4, 4, 5, 5 });
        Console.WriteLine(orderedBagOfInts);
        Console.WriteLine("Sub-range [5...10]: " +
            orderedBagOfInts.Range(5, true, 10, true));
        
        Console.Write("Set of Integers: ");
        Set<int> setOfInts = new Set<int>();
        setOfInts.Add(3);
        setOfInts.Add(5);
        setOfInts.Add(5);
        setOfInts.Add(5);
        setOfInts.Add(10);
        setOfInts.Add(20);
        setOfInts.Add(20);
        setOfInts.Remove(5);
        setOfInts.UnionWith(new Set<int>() { 3, 4, 5 });
        Console.WriteLine(setOfInts);

        Console.Write("OrderedSet of Integers: ");
        OrderedSet<int> orderedSetOfInts = new OrderedSet<int>();
        orderedSetOfInts.Add(3);
        orderedSetOfInts.Add(5);
        orderedSetOfInts.Add(5);
        orderedSetOfInts.Add(5);
        orderedSetOfInts.Add(10);
        orderedSetOfInts.Add(20);
        orderedSetOfInts.Add(20);
        orderedSetOfInts.Remove(5);
        orderedSetOfInts.UnionWith(new OrderedSet<int>() { 3, 4, 5 });
        Console.WriteLine(orderedSetOfInts);
        Console.WriteLine("Sub-range [5...20): " +
            orderedSetOfInts.Range(5, true, 20, false));

        Console.Write("MultiDictionary<string,int>: ");
        MultiDictionary<string, int> studentGrades =
            new MultiDictionary<string, int>(true);
        studentGrades.Add("Peter", 3);
        studentGrades.Add("Peter", 4);
        studentGrades.Add("Peter", 4);
        studentGrades.Add("Stanka", 6);
        studentGrades.Add("Stanka", 5);
        studentGrades.Add("Stanka", 6);
        studentGrades.Add("Tanya", 6);
        studentGrades.Add("Tanya", 4);
        Console.WriteLine(studentGrades);

        Console.WriteLine("OrderedMultiDictionary<string,int>:");
        OrderedMultiDictionary<int, string> distancesFromSofia =
            new OrderedMultiDictionary<int, string>(true);
        distancesFromSofia.Add(149, "Plovdiv");
        distancesFromSofia.Add(505, "Varna");
        distancesFromSofia.Add(394, "Bourgas");
        distancesFromSofia.Add(310, "Rousse");
        distancesFromSofia.Add(163, "Pleven");
        distancesFromSofia.Add(163, "Troyan");
        foreach (var distanceTowns in distancesFromSofia)
        {
            Console.WriteLine("\t" + distanceTowns);
        }

        Console.Write("Deque<string>: ");
        Deque<string> people = new Deque<string>();
        people.AddToBack("Kiro");
        people.AddToBack("Maria");
        people.AddToFront("Steve");
        people.AddManyToBack(new string[] { "Ivan", "Veronika" });
        Console.WriteLine(people);

        Console.Write("BigList<int>: ");
        IList<int> ints = new BigList<int>();
        //IList<int> ints = new List<int>();
        for (int i = 0; i < 1000000; i++)
        {
            ints.Add(i);
        }
        for (int i = 0; i < 50000; i++)
        {
            ints.Insert(i, i);
        }
        Console.WriteLine(ints.Count);
    }
}
