namespace AspNetWebApi.Models
{
    using System;
    using System.Linq.Expressions;

    using CodeFirst.Models;

    public class PostModel
    {
        public static Expression<Func<Post, PostModel>> FromPost
        {
            get
            {
                return x => new PostModel { Id = x.PostId, Title = x.Title, Content = x.Content, CreatedOn = x.CreatedOn, };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Post CreatePost()
        {
            return new Post { Content = this.Content, CreatedOn = this.CreatedOn, Title = this.Title };
        }

        public void UpdatePost(Post post)
        {
            if (this.Title != null)
            {
                post.Title = this.Title;
            }

            if (this.Content != null)
            {
                post.Content = this.Content;
            }
        }
    }
}