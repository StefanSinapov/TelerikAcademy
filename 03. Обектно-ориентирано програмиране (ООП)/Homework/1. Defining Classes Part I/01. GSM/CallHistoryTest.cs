/*
12. Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
	Create an instance of the GSM class.
	Add few calls.
	Display the information about the calls.
	Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
	Remove the longest call from the history and calculate the total price again.
	Finally clear the call history and print it.
 */
using System;
using System.Collections.Generic;
class CallHistoryTest
{
	static decimal pricePerMinute;
	static void PrintTotalCallsPrice(GSM gsm)
	{
		Console.WriteLine("--------------Price of all calls-----------");
		Console.WriteLine("Total: {0}", gsm.CalculateCallsPrice(pricePerMinute));
	}
	public static void Test()
	{
		//add new gsm
		GSM htc = new GSM("Desire X", "HTC");

		//add few calls
		htc.AddCall(new Call(DateTime.Parse("1.1.2013 23:30"), "0899819384", 0.30m));
		htc.AddCall(new Call(DateTime.Parse("14.1.2013 13:30"), "0899819384", 0.8m));
		htc.AddCall(new Call(DateTime.Parse("14.1.2013 13:40"), "0899819384", 3.40m));
		htc.AddCall(new Call(DateTime.Parse("29.1.2013 23:30"), "0888888888", 0.30m));


		//display the information about calls
		Console.WriteLine(htc);
		htc.PrintCallHistory();

		//calculate price of calls
		pricePerMinute = 0.37m;
		PrintTotalCallsPrice(htc);

		//Remove the longest call from the history and calculate the total price again.
		FindAndRemoveLongestCall(htc);
		PrintTotalCallsPrice(htc);

		//Finally clear the call history and print it.
		htc.ClearCalls();
		htc.PrintCallHistory();
		
	}

	static void FindAndRemoveLongestCall(GSM gsm)
	{
		decimal maxDuration = 0m;
		//find tha max durration
		foreach (var call in gsm.CallHistory)
		{
			if(call.Durration>maxDuration)
			{
				maxDuration = call.Durration;
			}
		}

		//remove tha max duration
		for (int i = 0; i < gsm.CallHistory.Count; i++)
		{
			if(gsm.CallHistory[i].Durration==maxDuration)
			{
				gsm.DeleteCall(gsm.CallHistory[i]);
			}
		}
	}
	
}

