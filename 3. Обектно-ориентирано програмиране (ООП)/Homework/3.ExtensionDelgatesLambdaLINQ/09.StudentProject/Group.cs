using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject
{
    public class Group
    {
        private int groupNumber;

        public Group(int groupNumber, string departmentName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departmentName;
        }

        public int GroupNumber
        {
            get { return this.groupNumber; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Group number can't be negative number!");
                }
                this.groupNumber = value;
            }
        }

        public string DepartmentName { get; set; }
    }
}
