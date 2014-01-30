using System;
class StringAndObjectTypes
{
	static void Main()
	{
		//Declare two string variables and assign them with “Hello” and “World”. 
		//Declare an object variable and assign it with the concatenation of the first two variables (mind adding an interval). 
		//Declare a third string variable and initialize it with the value of the object variable (you should perform type casting).

		string firstString = "Hello";
		string secondString = "World";
		object bothStringsToObject = firstString + " " + secondString;
		Console.WriteLine(bothStringsToObject);
		string thirdString = (string)bothStringsToObject;
		Console.WriteLine(thirdString);
	}
}

