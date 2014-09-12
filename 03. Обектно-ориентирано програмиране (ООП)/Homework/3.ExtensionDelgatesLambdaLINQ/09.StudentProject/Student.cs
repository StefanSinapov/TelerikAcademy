using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject
{
    //09.Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), GroupNumber.
    //Create a List<Student> with sample students. Select only the students that are from group number 2. Use LINQ query. Order the students by FirstName.

    public class Student
    {
        private string firstName;
        private string lastName;
        private string fn;
        private string email;
        private List<int> marks;
        private int groupNumber;
        private Group group;


        public Student(string firstName, string lastName, string fn, string tel, string email, List<int> marks, int groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FN = fn;
            this.Tel = tel;
            this.Email = email;
            this.marks = marks;
            this.GroupNumber = groupNumber;
        }

        public Student(string firstName, string lastName, string fn, string tel, string email, List<int> marks, int groupNumber, Group group)
            :this(firstName, lastName, fn, tel, email, marks, groupNumber)
        {
            this.group = group;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name can't be null, whitespace or empty!");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name can't be null, whitespace or empty!");
                }
                this.lastName = value;
            }
        }

        public string FN
        {
            get { return this.fn; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("FN can't be null, whitespace or empty!");
                }
                this.fn = value;
            }
        }

        public string Tel { get; private set; }

        public string Email
        {
            get { return this.email; }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email can't be null, whitespace or empty!");
                }
                this.email = value;
            }
        }

        public int GroupNumber
        {
            get { return this.groupNumber; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Group number can't be negative!");
                }
                this.groupNumber = value;
            }
        }

        public Group Group 
        {
            get { return this.group; }
            set
            {
                this.group = value;
            }
        }
        public List<int> Marks
        {
            get { return this.marks; }
        }

        public int MarksCount
        {
            get { return this.marks.Count; }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("Name: {0} {1}", this.FirstName, this.LastName);
            result.AppendLine();
            result.AppendLine("FN: " + this.FN);
            result.AppendLine("Tel: " + this.Tel);
            result.AppendLine("Email: " + this.Email);
            result.AppendLine("Marks: " + string.Join(", ", this.marks));
            result.Append("Group number: " + this.GroupNumber);

            return result.ToString();
        }
        public void AddMark(int mark)
        {
            if (mark >= 2 && mark <= 6)
            {
                this.marks.Add(mark);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid mark value! Mark value must be between 2 - 6!");
            }
        }

        public void RemoveMarkAt(int position)
        {
            if (position < 0 || position >= this.MarksCount)
            {
                throw new IndexOutOfRangeException("Can't remove mark at position: " + position + " Index is out of range!");
            }

            this.marks.RemoveAt(position);
        }

        public bool ContainMark(int mark)
        {
            return this.marks.Contains(mark);
        }

        public string GetMarks()
        {
            return string.Join(", ", this.marks);
        }
    }
}
