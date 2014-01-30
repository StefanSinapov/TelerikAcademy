using System;
using System.Collections.Generic;
using System.Linq;

class Accumulation
{
    static void Main()
    {
    }

    static List<int> AccumulateTwoNumbers(string first, string second)
    {
        // Convert string to int[] Array
        var a = first.Select(ch => ch - '0').ToArray();
        var b = second.Select(ch => ch - '0').ToArray();

        Array.Reverse(a);
        Array.Reverse(b);

        List<int> result = new List<int>(Math.Max(a.Length, b.Length));

        int carry = 0;

        for (int i = 0; i < result.Capacity; i++)
        {
            int num = (i < a.Length ? a[i] : 0) + (i < b.Length ? b[i] : 0) + carry;
            carry = num / 10;
            result.Add(num % 10);
        }

        if (carry > 0) result.Add(carry);

        return result;
    }
}