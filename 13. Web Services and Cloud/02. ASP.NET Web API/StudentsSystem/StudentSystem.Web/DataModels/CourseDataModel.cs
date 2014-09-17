namespace StudentSystem.Web.DataModels
{
    using System;
    using System.Linq.Expressions;
    using Models;

    public class CourseDataModel
    {
        public static Expression<Func<Course, CourseDataModel>> FromCourse
        {
            get
            {
                return c => new CourseDataModel
                {
                    Id = c.CourseId,
                    Description = c.Description
                };
            }
        }

        public CourseDataModel()
        {
            
        }

        public CourseDataModel(Course course)
        {
            this.Id = course.CourseId;
            this.Description = course.Description;
        }

        public int Id { get; set; }

        public string Description { get; set; }
    }
}