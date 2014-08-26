using System;
using System.Collections.Generic;

class LinkedListExample
{
    static void Main()
    {
        LinkedList<string> list = new LinkedList<string>();
        list.AddFirst("First");
        list.AddLast("Last");
        list.AddAfter(list.First, "After First");
        list.AddBefore(list.Last, "Before Last");

        Console.WriteLine(String.Join(", ", list));
        // Result: First, After First, Before Last, Last
    }
}
