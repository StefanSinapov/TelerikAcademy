using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Places.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
        public virtual ICollection<Category> Categories { get; set; }

        public Place()
        {
            Comments = new HashSet<Comment>();
            Votes = new HashSet<Vote>();
            Categories = new HashSet<Category>();
        }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Place> Places { get; set; }
        public Category()
        {
            this.Places = new HashSet<Place>();
        }
    }

    public class Vote
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Username { get; set; }
        public virtual ICollection<Place> Places { get; set; }
        public Vote()
        {
            this.Places = new HashSet<Place>();
        }
    }
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public string Username { get; set; }
        public virtual ICollection<Place> Places { get; set; }
        public Comment()
        {
            this.Places = new HashSet<Place>();
        }
    }
}
