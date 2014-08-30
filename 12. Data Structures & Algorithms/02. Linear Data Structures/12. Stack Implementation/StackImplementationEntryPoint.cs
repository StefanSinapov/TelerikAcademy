/* 12. Implement the ADT stack as auto-resizable array. 
 * Resize the capacity on demand (when no space is available
 * to add / insert a new element).*/
namespace _12.Stack_Implementation
{
    using System;

    class StackImplementationEntryPoint
    {
        static void Main()
        {
            var stack = new MyStack<string>();
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
}
