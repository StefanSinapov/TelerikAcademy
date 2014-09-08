namespace BookStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        private ICollection<Author> authors;
        private ICollection<Review> reviews;

        public Book()
        {
            this.authors = new HashSet<Author>();
            this.reviews = new HashSet<Review>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [MinLength(13), MaxLength(13)]
        public string Isbn { get; set; }

        public decimal? Price { get; set; }

        public string WebSite { get; set; }

        public virtual ICollection<Author> Authors
        {
            get { return this.authors; }
            set { this.authors = value; }
        }

        public virtual ICollection<Review> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }
    }
}