/*
 * Implement the data structure "set" in a
 * class HashedSet<T> using your class HashTable<K,T>
 * to hold the elements. Implement all standard set operations like Add(T), 
 * Find(T), Remove(T), Count, Clear(), 
 * union and intersect.
 */
namespace _05.Hash_Set_Implementation
{
    using System;

    class HashSetDemo
    {
        static void Main()
        {
            var firstSet = new HashSet<int>();

            firstSet.Add(2);
            firstSet.Add(2);
            firstSet.Add(5);
            firstSet.Add(2);
            firstSet.Add(3);

            Console.WriteLine("Elements in first set: {0}", firstSet);

            var secondSet = new HashSet<int> { 11, 5, 3, 2, 99 };
            Console.WriteLine("Elements in second set: {0}", secondSet);

            var setForUnion = new HashSet<int>(firstSet);
            setForUnion.UnionWith(secondSet);
            Console.WriteLine("Result of Union of two sets: {0}", setForUnion);

            var setForIntersect = new HashSet<int>(firstSet);
            setForIntersect.IntersectWith(secondSet);
            Console.WriteLine("Result of Intersection of two sets: {0}", setForIntersect);


            Console.WriteLine("\nSet: {0}", firstSet);
            const int valueForAdd = 22;
            firstSet.Add(valueForAdd);
            Console.WriteLine("After adding ({0}): {1}", valueForAdd, firstSet);

            const int valueForRemove = 5;
            firstSet.Remove(valueForRemove);
            Console.WriteLine("After removing ({0}): {1}", valueForRemove, firstSet);

            Console.WriteLine("\nSet: {0} \n Count: {1}", firstSet, firstSet.Count);
        }
    }
}
