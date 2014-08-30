/*
 * 11. Implement the data structure linked list. 
 * Define a class ListItem<T> that has two fields:
 * value (of type T) and NextItem (of type ListItem<T>). 
 * Define additionally a class LinkedList<T> with a single 
 * field FirstElement (of type ListItem<T>).
 */
namespace _11.LinkedList_Implementation
{
    using System;

    class LinkedListEntryPoint
    {
        static void Main()
        {
            var linkedList = new MyLinkedList<int>();

            linkedList.AddFirst(55);
            linkedList.AddFirst(22);
            linkedList.AddFirst(3);
            linkedList.AddFirst(11);

            Console.WriteLine("Count: {0}", linkedList.Count);
            PrintAllItems(linkedList);

            Console.WriteLine("After Add Last");
            linkedList.AddLast(999);
            PrintAllItems(linkedList);

            Console.WriteLine("After Remove 22:");
            linkedList.Remove(22);
            PrintAllItems(linkedList);

            Console.WriteLine("After Remove First:");
            linkedList.RemoveFirst();
            PrintAllItems(linkedList);

            Console.WriteLine("After Remove Last:");
            linkedList.RemoveLast();
            PrintAllItems(linkedList);

        }

        private static void PrintAllItems(MyLinkedList<int> linkedList)
        {
            Console.Write("     Items: ");
            foreach (var item in linkedList)
            {
                Console.Write("  {0}", item);
            }
            Console.WriteLine();
        }
    }
}
