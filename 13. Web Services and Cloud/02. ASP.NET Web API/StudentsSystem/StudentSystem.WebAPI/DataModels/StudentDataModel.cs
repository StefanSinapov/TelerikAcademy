namespace StudentSystem.WebAPI.DataModels
{
    using System.ComponentModel.DataAnnotations;
    using StudentSystem.Models;

    public class StudentDataModel
    {
        public StudentDataModel()
        {
        }

        public StudentDataModel(Student student)
        {
            StudentId = student.StudentId;
            Name = student.Name;
        }

        [Key]
        public int StudentId { get; set; }

        [MinLength(5)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}