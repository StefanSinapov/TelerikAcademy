/*
 * 4. Implement the data structure "hash table"
 * in a class HashTable<K,T>. Keep the data in array of 
 * lists of key-value pairs (LinkedList<KeyValuePair<K,T>>[]) 
 * with initial capacity of 16. When the hash table
 * load runs over 75%, perform resizing to 2 times larger capacity. 
 * Implement the following methods and properties: 
 *  Add(key, value), Find(key)?value, Remove( key), Count, Clear(), this[], Keys. 
 *  Try to make the hash table to support iterating over its elements with foreach.
 */
namespace _04.Hash_Table_Implementation
{
    using System;
    using System.Collections.Generic;

    class HashTableDemo
    {
        static void Main()
        {
            var table = new HashTable<string, string>
            {
                {"001", "Zara Ali"},
                {"002", "Abida Rehman"},
                {"003", "Joe Holzner"},
                {"004", "Mausam Benazir Nur"},
                {"005", "M. Amlan"},
                {"006", "M. Arif"},
                {"007", "Ritesh Saikia"}
            };


            if (table.ContainsKey("008"))
            {
                Console.WriteLine("This student name is already in the list");
            }
            else
            {
                Console.WriteLine("New Student added.");
                table.Add("008", "Nuha Ali");
            }

            // Get a collection of the keys. 
            ICollection<string> key = table.Keys;

            foreach (var keyValuePair in table)
            {
                Console.WriteLine("Key: {0}, Value: {1}", keyValuePair.Key, keyValuePair.Value);
            }
        }
    }
}
