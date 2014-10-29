namespace Articles.Web.Models
{
    public class Like
    {
        public int Id { get; set; }

        public bool? Value { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}