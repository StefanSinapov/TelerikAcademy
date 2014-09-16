namespace StudentSystem.WebAPI.DataModels
{
    using System;
    using StudentSystem.Models;

    public class HomeworkDataModel
    {
        public HomeworkDataModel()
        {
            
        }

        public HomeworkDataModel(Homework homework)
        {
            this.HomeworkId = homework.HomeworkId;
            this.Content = homework.Content;
            this.TimeSent = homework.TimeSent;
            this.CourseId = homework.CourseId;
            this.StudentId = homework.StudentId;
        }

        public int HomeworkId { get; set; }

        public string Content { get; set; }

        public DateTime? TimeSent { get; set; }

        public int CourseId { get; set; }

        public int? StudentId { get; set; }

    }
}