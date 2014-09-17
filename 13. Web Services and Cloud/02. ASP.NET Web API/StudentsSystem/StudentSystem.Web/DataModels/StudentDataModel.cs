namespace StudentSystem.Web.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Models;

	
    public class StudentDataModel
    {
        public static Func<Student, StudentDataModel> FromStudent
        {
            get
            {
                return student => new StudentDataModel
                {
					Id = student.StudentId,
					Name = student.Name, 
                };
            }
        }

        public static Func<StudentDataModel, Student> ModelFromData
        {
            get
            {
                return s => new Student
                {
                    Name = s.Name,
                };
            }
        }

        public StudentDataModel()
        {
            
        }

        public StudentDataModel(Student student)
        {
            this.Id = student.StudentId;
            this.Name = student.Name;
        }

        public int Id { get; set; }

        [MinLength(5)]
        [MaxLength(100)]
        public string Name { get; set; }
		
    }
	
}