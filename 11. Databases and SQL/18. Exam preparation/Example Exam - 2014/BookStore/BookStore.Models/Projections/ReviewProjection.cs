namespace BookStore.Models.Projections
{
    using System;

    public class ReviewProjection
    {
        public string Content { get; set; }

        public DateTime DateOfCreation { get; set; }

        public string[] AuthorName { get; set; }

        public string BookName { get; set; } 
    }
}