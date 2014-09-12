using System;
using System.Collections.Generic;
using System.Text;
namespace StudentsTest
{
	public class Student
	{
		//Fields
		private string firstName;
		private string lastName;
		private string fn;
		private string phoneNumber;
		private string email;
		private List<int> marks;
		private int groupNumber;

		//Constructors
		public Student(string firstName,string lastName, string fn, string phoneNumber,string email,List<int> marks,int groupNumber)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.FN = fn;
			this.PhoneNumber = phoneNumber;
			this.Email = email;
			this.Marks = marks;
			this.GroupNumber = groupNumber;
		}

		//Properties
		public string Email
		{
			get { return this.email; }
			set { this.email = value; }
		}
		public int GroupNumber
		{
			get { return this.groupNumber; }
			set { this.groupNumber = value; }
		}
		public List<int> Marks
		{
			get { return this.marks; }
			set { this.marks = value; }
		}
		public string PhoneNumber
		{
			get { return this.phoneNumber; }
			set { this.phoneNumber = value; }
		}
		public string FN
		{
			get { return this.fn; }
			set { this.fn = value; }
		}
		public string LastName
		{
			get { return this.lastName; }
			set { this.lastName = value; }
		}
		public string FirstName
		{
			get { return this.firstName; }
			set { this.firstName = value; }
		}

		//Override
		public override string ToString()
		{
			StringBuilder result = new StringBuilder();

			result.AppendFormat("Name: {0} {1}", this.FirstName, this.LastName);
			result.AppendLine();
			result.AppendLine("FN: " + this.FN);
			result.AppendLine("Tel: " + this.PhoneNumber);
			result.AppendLine("Email: " + this.Email);
			result.AppendLine("Marks: " + string.Join(", ", this.marks));
			result.Append("Group number: " + this.GroupNumber);

			return result.ToString();
		}
	}
}
