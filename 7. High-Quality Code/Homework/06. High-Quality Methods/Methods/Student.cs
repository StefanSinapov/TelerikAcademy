namespace Methods
{
    using System;

    public class Student
    {
        private string firstName;
        private string lastName;
        private DateTime birthDate;

        public Student(string firstName, string lastName, DateTime birthDate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name cannot be empty.");
                }
                else if (value.Length <= 3)
                {
                    throw new ArgumentException("First name must be at least 3 symbols");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name cannot be empty.");
                }
                else if (value.Length <= 3)
                {
                    throw new ArgumentException("Last name must be at least 3 symbols");
                }

                this.lastName = value;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return this.birthDate;
            }

            set
            {
                DateTime bottomDateTime = new DateTime(1900, 1, 1);
                DateTime topDateTime = DateTime.Now;

                if (!(value >= bottomDateTime && value <= topDateTime))
                {
                    string errorMessage = string.Format(
                        "Birthdate must be in the range [{0}; {1}]",
                        bottomDateTime.ToShortDateString(),
                        topDateTime.ToShortDateString());
                    throw new ArgumentException(errorMessage);
                }

                this.birthDate = value;
            }
        }

        public bool IsOlderThan(Student other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Student cannot be null ref");
            }

            bool isOlder = this.BirthDate < other.BirthDate;
            return isOlder;
        }
    }
}
