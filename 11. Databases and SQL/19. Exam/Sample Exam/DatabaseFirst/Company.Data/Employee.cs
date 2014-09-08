//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Company.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public Employee()
        {
            this.Employees1 = new HashSet<Employee>();
            this.EmployeesProjects = new HashSet<EmployeesProject>();
            this.Reports = new HashSet<Report>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal YearSalary { get; set; }
        public Nullable<int> ManagerId { get; set; }
        public int DepartmentId { get; set; }
    
        public virtual ICollection<Employee> Employees1 { get; set; }
        public virtual Employee Employee1 { get; set; }
        public virtual ICollection<EmployeesProject> EmployeesProjects { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
