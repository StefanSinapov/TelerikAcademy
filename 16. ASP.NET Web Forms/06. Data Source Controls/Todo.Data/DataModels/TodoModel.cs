namespace Todo.Data.DataModels
{
    using System;

    public class TodoModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public DateTime LastModified { get; set; }

        public string Content { get; set; }
    }
}