namespace _03.CompanyInformation
{
	using System;
	class CompanyInformation
	{
		static void Main()
		{
			Console.Write("Company Name: ");
			string compName=Console.ReadLine();
			Console.Write("Company Address: ");
			string compAddres = Console.ReadLine();
			Console.Write("Company Phone Number: ");
			string compPhoneNumber = Console.ReadLine();
			Console.Write("Company Fax: ");
			string compFax = Console.ReadLine();
			Console.Write("Company Web Site: ");
			string compWebSite = Console.ReadLine();

			object company = compName + "\n" + compAddres + "\nPhone Number:" + compPhoneNumber + "\nFax:" + compFax + "\n" + compWebSite;

			Console.Write("Manager's first name: ");
			string manFistName = Console.ReadLine();
			Console.Write("Manager's last name: ");
			string manLastName = Console.ReadLine();
			Console.Write("Manager's age: ");
			int manAge = int.Parse(Console.ReadLine());
			Console.Write("Manager's phone number: ");
			string manPhoneNumber = Console.ReadLine();
			object manager=manFistName + "\n" +manLastName + "\nAge: " +manAge + "\nPhone Number:" +manPhoneNumber;

			Console.WriteLine("\n\n");
			Console.WriteLine("Company Info: \n{0} \n\nManager Info \n{1}",company,manager);
		}
	}
}
