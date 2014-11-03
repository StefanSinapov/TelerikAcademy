﻿namespace Todo.Models
{
    using System;

    public class Todo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime LastModified { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
