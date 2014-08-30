namespace _13.Queue_Implementation
{
    using System;

    class QueueImplementationEntryPoint
    {
        static void Main()
        {
            var queue = new MyQueue<string>();
            queue.Enqueue("Message One");
            queue.Enqueue("Message Two");
            queue.Enqueue("Message Three");
            queue.Enqueue("Message Four");
            while (queue.Count > 0)
            {
                string message = queue.Dequeue();
                Console.WriteLine(message);
            }

        }
    }
}
