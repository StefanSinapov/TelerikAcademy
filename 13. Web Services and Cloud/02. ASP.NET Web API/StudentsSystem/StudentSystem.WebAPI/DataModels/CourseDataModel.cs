namespace StudentSystem.WebAPI.DataModels
{
    using System.ComponentModel.DataAnnotations;
    using StudentSystem.Models;

    public class CourseDataModel
    {
        public CourseDataModel()
        {
            
        }

        public CourseDataModel(Course course)
        {
            this.CourseId = course.CourseId;
            this.Description = course.Description;
        }

        [Required]
        public int CourseId { get; set; }

        public string Description { get; set; }

    }
}