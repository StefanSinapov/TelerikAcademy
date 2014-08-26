using System;
using System.Collections.Generic;

class ListSimpleExample
{
    static void Main()
    {
        List<string> list = new List<string>() { "C#", "Java" };
        list.Add("SQL");
        list.Add("Python");
        foreach (string item in list)
        {
            Console.WriteLine(item);
        }
        // Result:
        //   C#
        //   Java
        //   SQL
        //   Python
    }
}
