/*
 * Create a class Person with two fields – name and age. 
 * Age can be left unspecified (may contain null value. 
 * Override ToString() to display the information of a person and if age is
 * not specified – to say so. Write a program to test this functionality.
 */
using System;
using System.Collections.Generic;


namespace Persons
{
	class Program
	{
		static void Main()
		{
			List<Person> people = new List<Person>
			{
				new Person("Stefan Dimitrov"),
				new Person("Petka Sinapova",20),
				new Person("Ivan Georgiev",8)
			};

			foreach (var person in people)
			{
				Console.WriteLine(person);
			}
		}
	}
}
