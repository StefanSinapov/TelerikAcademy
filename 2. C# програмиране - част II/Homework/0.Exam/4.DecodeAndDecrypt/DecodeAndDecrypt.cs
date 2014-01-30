using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DecodeAndDecrypt
{
	static void Main()
	{
		StringBuilder decodedMessage = new StringBuilder();
		string cypherText = Console.ReadLine();

		string tmp_cypherLength = string.Empty;
		StringBuilder cypher = new StringBuilder();

		int cypherLength = 0;

		// Get length of the cypher
		for (int i = cypherText.Length - 1; i >= 0; i--)
		{
			if (char.IsDigit(cypherText[i]))
			{
				tmp_cypherLength = cypherText[i] + tmp_cypherLength;
			}
			else
			{
				break;
			}
		}

		if (tmp_cypherLength.Length > 0)
		{
			cypherLength = int.Parse(tmp_cypherLength);
		}

		//decode 5a-> aaaaa
		for (int i = 0; i < cypherText.Length - tmp_cypherLength.Length; i++)
		{
			if (char.IsDigit(cypherText[i]))
			{
				string digit = "" + cypherText[i];
				while (char.IsDigit(cypherText[i + 1]))
				{
					i++;
					digit += cypherText[i];
				}
				for (int j = 0; j < int.Parse(digit); j++)
				{
					decodedMessage.Append(cypherText[i + 1]);
				}
				i++;
			}
			else
			{
				decodedMessage.Append(cypherText[i]);
			}
		}

		
		StringBuilder encryptedMessage = new StringBuilder();

		//Get cypher
		if (cypherLength > 0)
		{
			for (int i = decodedMessage.Length - 1, count = 0; i >= 0; i--, count++)
			{
				if (count < cypherLength)
				{
					cypher.Append(decodedMessage[i]);
				}
				else
				{
					encryptedMessage.Append(decodedMessage[i]);
				}
			}
		}

		//Reverse 
		encryptedMessage = new StringBuilder(new string(encryptedMessage.ToString().Reverse().ToArray()));
		cypher = new StringBuilder(new string(cypher.ToString().Reverse().ToArray()));

		StringBuilder message = new StringBuilder();
		if (cypher.Length > encryptedMessage.Length)
		{
			for (int i = 0; i < encryptedMessage.Length; i++)
			{
				int result = (encryptedMessage[i] - 'A') ^ (cypher[i] - 'A');
				if (cypher.Length > encryptedMessage.Length)
				{
					if (encryptedMessage.Length + i < cypher.Length)
					{
						result = result ^ (cypher[encryptedMessage.Length + i] - 'A');
					}

				}
				message.Append((char)(result + 65));
			}
		}
		else
		{
			for (int i = 0; i < encryptedMessage.Length; i++)
			{
				int result = (encryptedMessage[i] - 'A') ^ (cypher[i % cypher.Length] - 'A');
				message.Append((char)(result + 65));
			}
		}


		Console.WriteLine(message.ToString());
	}
}

