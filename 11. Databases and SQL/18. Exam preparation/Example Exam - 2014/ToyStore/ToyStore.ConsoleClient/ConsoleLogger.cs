namespace ToyStore.ConsoleClient
{
    using System;
    using DataGenerators.Contracts;

    public class ConsoleLogger : ILogger
    {
        public void Log(string text)
        {
            Console.Write(text);
        }
    }
}