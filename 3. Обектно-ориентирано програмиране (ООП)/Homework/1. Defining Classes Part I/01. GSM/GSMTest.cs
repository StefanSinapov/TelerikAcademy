/*
 * 1.Define a class that holds information about a mobile phone device: 
 * model, manufacturer, price, owner, battery characteristics (model, hours idle and hours talk) 
 * and display characteristics (size and number of colors). Define 3 separate classes 
 * (class GSM holding instances of the classes Battery and Display).
 * 
 * 7. Write a class GSMTest to test the GSM class:
	 * Create an array of few instances of the GSM class.
	 * Display the information about the GSMs in the array.
	 * Display the information about the static property IPhone4S.

 */
using System;
using System.Collections.Generic;
class GSMTest
{

	static void Main()
	{
		List<GSM> mobilePhones = new List<GSM>();

		//first phone
		mobilePhones.Add(new GSM("Asha", "Nokia"));

		//second phone
		{
			GSM mobile = new GSM("Desire X","HTC");
			mobile.Owner = "Ivan";
			mobile.Price = 300;

			mobile.Battery = new Battery(Battery.Type.LiIon);
			mobile.Display = new Display(4);

			mobilePhones.Add(mobile);
		}

		foreach (GSM  gsm in mobilePhones)
		{
			Console.WriteLine(gsm);
		}

		//iphone
		Console.WriteLine(GSM.IPhone4S);
	}
}