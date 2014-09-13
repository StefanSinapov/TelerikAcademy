namespace _03.Supermarket
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    class SupermarketDemo
    {
        static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif
            string command;
            string[] arguments;
            var supermarket = new Supermarket();


            var input = Console.ReadLine();

            while (input != "End")
            {
                var indexOfFirstSpace = input.IndexOf(' ');

                command = input.Substring(0, indexOfFirstSpace).Trim();
                arguments = input.Substring(indexOfFirstSpace + 1, input.Length - 1 - indexOfFirstSpace).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (command == "Append")
                {
                    supermarket.Append(arguments[0]);
                }
                else if (command == "Insert")
                {
                    supermarket.Insert(int.Parse(arguments[0]), arguments[1]);
                }
                else if (command == "Find")
                {
                    supermarket.Find(arguments[0]);
                }
                else if (command == "Serve")
                {
                    supermarket.Serve(int.Parse(arguments[0]));
                }

                input = Console.ReadLine();
            }
        }

    }

    public class Supermarket
    {
        private BigList<string> collection;
        private Dictionary<string, int> names;

        public Supermarket()
        {
            this.collection = new BigList<string>();
            this.names = new Dictionary<string, int>();
        }

        public void Append(string name)
        {
            this.collection.Add(name);

            AddNameToNamesCollection(name);

            Console.WriteLine("OK");
        }

        public void Insert(int index, string name)
        {
            if (index < 0 || index > this.collection.Count)
            {
                Console.WriteLine("Error");
                return;
            }


            this.collection.Insert(index, name);
            this.AddNameToNamesCollection(name);

            Console.WriteLine("OK");
        }

        public void Find(string name)
        {
            if (!this.names.ContainsKey(name))
            {
                Console.WriteLine("0");
                return;
            }

            Console.WriteLine(this.names[name]);
        }

        public void Serve(int count)
        {
            if (count > this.collection.Count)
            {
                Console.WriteLine("Error");
                return;
            }

            var output = this.collection.GetRange(0, count);

            foreach (var name in output)
            {
                this.names[name]--;
            }

            this.collection.RemoveRange(0, count);
            Console.WriteLine(string.Join(" ", output));
        }

        private void AddNameToNamesCollection(string name)
        {
            if (!this.names.ContainsKey(name))
            {
                this.names.Add(name, 0);
            }

            this.names[name]++;
        }

    }
}
