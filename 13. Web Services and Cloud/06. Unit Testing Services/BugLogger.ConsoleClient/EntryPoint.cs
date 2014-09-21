namespace BugLogger.ConsoleClient
{
    using System;
    using System.Linq;
    using Data;

    class EntryPoint
    {
        static void Main()
        {
            var data = new BugLoggerData();

            foreach (var bug in data.Bugs.All().ToArray())
            {
                Console.WriteLine(bug);
            }
        }
    }
}
