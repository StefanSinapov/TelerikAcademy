using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HttpRequestResponseMessage.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
    }
}