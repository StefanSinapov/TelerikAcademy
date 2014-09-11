using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON.NET.Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person() { FirstName = "Doncho", LastName = "Minkov", Age = 24 };
            var personJSON = JsonConvert.SerializeObject(person);
            Console.WriteLine("Serialized:");
            Console.WriteLine(personJSON);

            Console.WriteLine();

            Person personDeserialized = JsonConvert.DeserializeObject<Person>(personJSON);
            Console.WriteLine("Deserialized (FullName):");
            Console.WriteLine(personDeserialized.FullName);

            /* Complex object serialization and deserialization
            Dictionary<string, Dictionary<string, string>> dict = new Dictionary<string, Dictionary<string, string>>();
            for (var i = 0; i < 10; i++)
            {
                var innerDict = new Dictionary<string, string>();
                for (var j = 0; j < 5; j++)
                {
                    innerDict["inner key #" + j + " in #" + i] = "value #" + j + " in #" + i;
                }
                dict["key #" + i] = innerDict;
            }
            var jsonDict = JsonConvert.SerializeObject(dict);
            Console.WriteLine(jsonDict);

            var deserializedDict = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(jsonDict);
            foreach (var keyValPair in deserializedDict)
            {
                var innerDict = keyValPair.Value;
                foreach (var item in innerDict)
                {
                    Console.WriteLine(item);
                }
            }
            */
        }
    }
}
