using System;

class ReplaceStartEnd
{
    static string ReplaceEnd(string input, char oldChar, char newChar)
    {
        char[] splitted = input.ToCharArray();

        for (int ct = splitted.Length - 1; ct >= 0; ct--)
        {
            if (splitted[ct] == oldChar)
            {
                splitted[ct] = newChar;
            }
            else
            {
                break;
            }
        }

        return new String(splitted);
    }

    static string ReplaceStart(string input, char oldChar, char newChar)
    {
        char[] splitted = input.ToCharArray();

        for (int ct = 0; ct < splitted.Length; ct++)
        {
            if (splitted[ct] == oldChar)
            {
                splitted[ct] = newChar;
            }
            else
            {
                break;
            }
        }

        return new String(splitted);
    }

    static void Main()
    {
        string text = "AAAAABBAACCAABB";

        Console.WriteLine(text + "\n");
        Console.WriteLine(ReplaceEnd(text, 'B', '*'));
        Console.WriteLine(ReplaceStart(text, 'A', '-'));
    }
}