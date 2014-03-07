using System;
using System.Text;
using System.Linq;

namespace Students
{
	public class Student: ICloneable, IComparable<Student>
	{
		//Fields
		private string firstName;
		private string middleName;
		private string lastName;
		private string ssn;
		private string address;
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public Specialty Specialty { get; set; }
		public University Univesity { get; set; }
		public Faculty Faculty { get; set; }


		//Constructor
		public Student(string initialFistName, string initialMiddleName, string initialLastName, string initialSSN,
			Specialty initialSpecialty, University initialUniversity, Faculty initialFaculty,
			string initialAddress = null, string initialEmail = null, string initialPhoneNumber = null)
		{
			this.FirstName = initialFistName;
			this.MiddleName = initialMiddleName;
			this.LastName = initialLastName;
			this.SSN = initialSSN;
			this.Specialty = initialSpecialty;
			this.Univesity = initialUniversity;
			this.Faculty = initialFaculty;
			this.Address = initialAddress;
			this.Email = initialEmail;
			this.PhoneNumber = initialPhoneNumber;
		}


		public string FirstName
		{
			get { return this.firstName; }
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentNullException("First name cannot be null");
				this.firstName = value;
			}
		}
		public string MiddleName
		{
			get { return this.middleName; }
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentNullException("Middle name cannot be null");
				this.middleName = value;
			}
		}
		public string LastName
		{
			get { return this.lastName; }
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentNullException("Last name cannot be null");
				this.lastName = value;
			}
		}
		public string SSN
		{
			get { return this.ssn; }
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentNullException("SSN cannot be null");
				this.ssn = value;
			}
		}
		private string Address
		{
			get { return this.address; }
			set
			{
				//if (string.IsNullOrEmpty(value))
				//	throw new ArgumentNullException("Address cannot be null");
				this.address = value;
			}
		}

		public override bool Equals(object other)
		{
			return this.SSN.Equals((other as Student).SSN);
		}

		public override int GetHashCode()
		{
			return this.SSN.GetHashCode();
		}

		public static bool operator ==(Student firstStudent, Student secondStudent)
		{
			return firstStudent.Equals(secondStudent);
		}

		public static bool operator !=(Student firstStudent, Student secondStudent)
		{
			return !firstStudent.Equals(secondStudent);
		}

		public override string ToString()
		{
			StringBuilder info = new StringBuilder();
			info.AppendLine("--> Student");
			info.AppendLine(string.Format("   {0} {1} {2}", this.FirstName, this.MiddleName, this.LastName));
			info.AppendLine("   SSN: " + this.SSN);
			if (this.Address != null)
			{
				info.AppendLine(string.Format("   Addres: {0}", this.Address));
			}
			if (this.Email != null)
			{
				info.AppendLine(string.Format("   Email: {0}", this.Email));
			}
			if (this.PhoneNumber != null)
			{
				info.AppendLine(string.Format("   Phone number: {0}", this.PhoneNumber));
			}

			info.AppendLine("   University: " + this.Univesity);
			info.AppendLine("   Faculty: " + this.Faculty);
			info.AppendLine("   Specialty: " + this.Specialty);

			return info.ToString();
		}


		public object Clone()
		{
			return new Student(this.FirstName,this.MiddleName,this.LastName,this.SSN,this.Specialty,this.Univesity
				,this.Faculty, this.Address,this.Email,this.PhoneNumber);
		}

		public int CompareTo(Student other)
		{
			if (this.Equals(other))
				return 0;

			var firstStudent = new Student[] { this, other }.OrderBy((student) => student.FirstName)
														.ThenBy((student) => student.MiddleName)
														.ThenBy((student) => student.LastName)
														.ThenBy((student) => student.SSN)
														.First();
			return this.Equals(firstStudent) ? -1 : 1;
		}
	}
}
