namespace AspNetWebApi.Client
{
    using System;

    internal class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
