using System;
using System.Text;
using System.Collections.Generic;
class EncodeAndEncrypt
{

	static char CharEncrypt(char messageSymbol, char cypherSymbol)
	{
		char result = '0';
		int messageSymbolCode = messageSymbol - 'A';
		int cypherSymbolCode = cypherSymbol - 'A';
		int XOR = messageSymbolCode ^ cypherSymbolCode;
		result = (char)(XOR + 'A');
		return result;
	}
	static string EncryptMessegeBigger(string message, string cypher)
	{
		StringBuilder result = new StringBuilder();
		int cypherIndex = 0;
		for (int i = 0; i < message.Length; i++)
		{
			if (cypherIndex == cypher.Length)
			{
				cypherIndex = 0;
			}
			cypherIndex++;
			char messageSymbol = message[i];
			char cypherSymbol = cypher[cypherIndex];
			char encryptedSymbol = CharEncrypt(messageSymbol, cypherSymbol);
			result.Append(encryptedSymbol, 1);
		}
		return result.ToString();
	}

	static string EncryptCypherBigger(string message, string cypher)
	{
		StringBuilder result = new StringBuilder(message);
		int messageIndex = 0;
		for (int i = 0; i < cypher.Length; i++)
		{
			if (messageIndex == message.Length)
			{
				messageIndex = 0;
			}
			char messageSymbol = message[messageIndex];
			char cypherSymbol = cypher[i];
			char encryptedSymbol = CharEncrypt(messageSymbol, cypherSymbol);
			//to add
		}


		return result.ToString();
	}

	static string Encrypt(string message, string cypher)
	{
		string result;
		if (message.Length > cypher.Length)
		{
			result = EncryptMessegeBigger(message, cypher);
		}
		else
		{
			result = EncryptCypherBigger(message, cypher);
		}
		return result;
	}


	static string Encode(string text)
	{
		StringBuilder result = new StringBuilder();
		char previousSymbol = text[0];
		int counter = 0;
		for (int i = 0; i < text.Length; i++)
		{

			if (text[i] == previousSymbol)
			{
				counter++;
			}
			else
			{
				if (counter == 1)
				{
					result.Append(previousSymbol);

				}
				else if (counter == 2)
				{
					result.Append(previousSymbol, 2);
				}
				else
				{
					result.Append(counter + previousSymbol.ToString());
				}
				counter = 1;
			}
			previousSymbol = text[i];
		}
		if (text[text.Length-1] == previousSymbol)
		{
			counter++;
		}
		else
		{
			if (counter == 1)
			{
				result.Append(previousSymbol);

			}
			else if (counter == 2)
			{
				result.Append(previousSymbol, 2);
			}
			else
			{
				result.Append(counter + previousSymbol.ToString());
			}
			counter = 1;
		}
		return result.ToString();
	}


	static void Main()
	{
		string message = Console.ReadLine();
		string cypher = Console.ReadLine();



		int lengthOfCypher = cypher.Length;
		string finalResult = Encode(Encrypt(message, cypher) + cypher) + lengthOfCypher;
	}
}
