using System;
using System.Collections.Generic;

class StackExample
{
    static void Main()
    {
        Stack<string> stack = new Stack<string>();
		
        stack.Push("1. Ivan");
        stack.Push("2. Nikolay");
        stack.Push("3. Maria");
        stack.Push("4. George");
		
        Console.WriteLine("Top = {0}", stack.Peek());
        while (stack.Count > 0)
        {
            string personName = stack.Pop();
            Console.WriteLine(personName);
        }
    }
}
