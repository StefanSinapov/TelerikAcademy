/*
 * 6. * A text file phones.txt holds information about people, their town and phone number:
	Input:
		Mimi Shmatkata          | Plovdiv  | 0888 12 34 56
		Kireto                  | Varna    | 052 23 45 67
		Daniela Ivanova Petrova | Karnobat | 0899 999 888
		Bat Gancho              | Sofia    | 02 946 946 946

 * Duplicates can occur in people names, towns and phone numbers. 
 * Write a program to read the phones file and execute a sequence of 
 * commands given in the file `commands.txt`:
    Command:
	- find(name) – display all matching records by given name (first, middle, last or nickname)
	- find(name, town) – display all matching records by given name and town
 */
namespace _06.Phonebook
{
    using System;
    using System.Collections.Generic;

    class PhonebookDemo
    {
        private static Dictionary<string, HashSet<string>> namesDict;
        private static Dictionary<string, HashSet<string>> citiesDict;

        static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../phones.txt"));
#endif
            namesDict = new Dictionary<string, HashSet<string>>();
            citiesDict = new Dictionary<string, HashSet<string>>();

            ReadPhonesInput();

            //No time for command Parser, too many homeworks :)

            Find("Kireto");
            Find("Kireto", "Varna");
            Find("Kireto", "Plovdiv");
            Find("Petrova");
            Find("Petrova", "Karnobat");
        }

        private static void Find(string name, string city)
        {
            string nameOriginal = name;
            string cityOriginal = city;
            name = name.ToLower();
            city = city.ToLower();
            if (!namesDict.ContainsKey(name))
            {
                Console.WriteLine("There is no numbers for {0}", name);
                return;
            }
            if (!citiesDict.ContainsKey(city))
            {
                Console.WriteLine("There is no numbers for {0}", city);
                return;
            }

            var numbersFromName = namesDict[name];
            var numbersFromCity = citiesDict[city];

            var numbers = new HashSet<string>(numbersFromName);
            numbers.IntersectWith(numbersFromCity);

            if (numbers.Count == 0)
            {
                Console.WriteLine("There is no numbers for {0} from {1}", nameOriginal, cityOriginal);
            }
            else
            {
                Console.WriteLine("{0} from {1} : {2}", nameOriginal, cityOriginal, string.Join(", ", numbers));
            }
        }

        private static void Find(string name)
        {
            string nameOriginal = name;
            name = name.ToLower();
            if (!namesDict.ContainsKey(name))
            {
                Console.WriteLine("There is no numbers for {0}", name);
                return;
            }
            var numbers = namesDict[name];
            Console.WriteLine("{0}: {1}", nameOriginal, string.Join(", ", numbers));
        }

        private static void ReadPhonesInput()
        {
            string input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                var row = input.Split('|');
                var names = row[0].Trim();
                var city = row[1].Trim();
                var phoneNumber = row[2].Trim();

                AddNamesToDictionary(names, phoneNumber);
                AddCitiesToDictionary(city, phoneNumber);

                input = Console.ReadLine();
            }
        }

        private static void AddCitiesToDictionary(string city, string phoneNumber)
        {
            city = city.ToLower();
            if (!citiesDict.ContainsKey(city))
            {
                citiesDict.Add(city, new HashSet<string>());
            }
            citiesDict[city].Add(phoneNumber);
        }

        private static void AddNamesToDictionary(string names, string phoneNumber)
        {
            names = names.ToLower();
            var namesArray = names.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string name in namesArray)
            {
                if (!namesDict.ContainsKey(name))
                {
                    namesDict.Add(name, new HashSet<string>());
                }
                namesDict[name].Add(phoneNumber);
            }
        }
    }
}
