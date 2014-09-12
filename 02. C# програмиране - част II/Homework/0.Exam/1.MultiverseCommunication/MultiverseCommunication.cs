using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class MultiverseCommunication
{
	static double Pow(int number, int power)
	{
		if (power == 0)
		{
			return 1;
		}
		double pass = number;
		for (int ct = 1; ct < power; ct++)
		{
			pass *= number;
		}

		return pass;
	}
	static Dictionary<string, int> table = new Dictionary<string, int>(){
	{"CHU",0},
	{"TEL",1} ,
	{"OFT",2 },
	{"IVA",3 },
	{"EMY",4 },
	{"VNB",5 },
	{"POQ",6 },
	{"ERI",7 },
	{"CAD",8 },
	{"K-A",9 },
	{"IIA",10},
	{"YLO",11},
	{"PLA",12},
	};

	static void Main()
	{
		string message = Console.ReadLine();
		BigInteger result = new BigInteger();
		int index=message.Length/3;

		for (int i = 0; i < message.Length; i+=3)
		{
			string currentMessage = message.Substring(i, 3);
			result += (BigInteger)table[currentMessage] * (BigInteger)Pow(13, index - 1);
			index--;
		}

		Console.WriteLine(result);
	}
}

