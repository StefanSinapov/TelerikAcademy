namespace StudentSystem.Web.DataModels
{
    using System;
    using System.Linq.Expressions;
    using Models;

    public class HomeworkDataModel
    {
        public static Func<Homework, HomeworkDataModel> FromHomework
        {
            get
            {
                return h => new HomeworkDataModel
                {
                   Id = h.HomeworkId,
                   Content = h.Content,
                   CourseId = h.CourseId,
                   StudentId = h.StudentId
                };
            }
        }

        public static Func<HomeworkDataModel, Homework> ModelFromData
        {
            get
            {
                return h => new Homework
                {
                    Content = h.Content,
                    TimeSent = h.TimeSent,
                    CourseId = h.CourseId,
                    StudentId = h.StudentId,
                };
            }
        }

        public HomeworkDataModel()
        {
            
        }

        public HomeworkDataModel(Homework homework)
        {
            this.Id = homework.HomeworkId;
            this.Content = homework.Content;
            this.TimeSent = homework.TimeSent;
            this.CourseId = homework.CourseId;
            this.StudentId = homework.StudentId;
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime? TimeSent { get; set; }

        public int CourseId { get; set; }

        public int? StudentId { get; set; }
    }
}