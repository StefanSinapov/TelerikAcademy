using System;
using System.Collections.Generic;

class QueueExample
{
	static void Main()
	{
		Queue<string> queue = new Queue<string>();

        queue.Enqueue("Message One");
		queue.Enqueue("Message Two");
		queue.Enqueue("Message Three");
		queue.Enqueue("Message Four");
		queue.Enqueue("Message Five");
		
        while (queue.Count > 0)
		{
			string message = queue.Dequeue();
			Console.WriteLine(message);
		}
	}
}
