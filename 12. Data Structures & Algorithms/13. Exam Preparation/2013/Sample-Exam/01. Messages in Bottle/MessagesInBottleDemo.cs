namespace _01.Messages_in_Bottle
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class MessagesInBottleDemo
    {
        private static readonly Dictionary<char, string> Cipher = new Dictionary<char, string>();
        private static readonly SortedSet<string> ResultSet = new SortedSet<string>();
        private static string secredMessage;

        static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            secredMessage = Console.ReadLine();
            var cipherString = Console.ReadLine();

            char key = char.MinValue;
            var value = new StringBuilder();
            for (int i = 0; i < cipherString.Length; i++)
            {
                if ('A' <= cipherString[i] && cipherString[i] <= 'Z')
                {

                    if (i > 0)
                    {
                        if (Cipher.ContainsKey(key))
                        {
                            Cipher[key] = value.ToString();
                        }
                        else
                        {
                            Cipher.Add(key, value.ToString());
                        }
                        value.Clear();
                    }

                    key = cipherString[i];
                }
                else
                {
                    value.Append(cipherString[i]);
                }
            }

            Cipher.Add(key, value.ToString());
            value.Clear();

            Decipher(0, new StringBuilder());

            Console.WriteLine(ResultSet.Count);
            foreach (var result in ResultSet)
            {
                Console.WriteLine(result);
            }
        }

        private static void Decipher(int secredMsgIndex, StringBuilder result)
        {
            if (secredMsgIndex == secredMessage.Length)
            {
                ResultSet.Add(result.ToString());
                return;
            }

            foreach (var item in Cipher)
            {
                if (secredMessage.Substring(secredMsgIndex).StartsWith(item.Value))
                {
                    Decipher(secredMsgIndex + item.Value.Length, result.Append(item.Key));
                    result.Length--;
                }
            }
        }
    }


}
