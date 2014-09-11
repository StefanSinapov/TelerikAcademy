namespace AspNetWebApi.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using AspNetWebApi.Models;

    using CodeFirst.Data;
    using CodeFirst.Models;

    public class PostsController : ApiController
    {
        private readonly IRepository<Post> data;

        public PostsController(IRepository<Post> data)
        {
            this.data = data;
        }

        public PostsController()
        {
            this.data = new EfRepository<Post>(new ForumDbContext());
        }

        public HttpResponseMessage Get(int id)
        {
            var post = this.data.All().Where(x => x.PostId == id).Select(PostModel.FromPost).FirstOrDefault();
            if (post == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found!");
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, post);
        }

        public IQueryable<PostModel> Get(string category)
        {
            var posts = this.data.All().Where(x => x.Category.Name == category).Select(PostModel.FromPost);
            return posts;
        }

        public IQueryable<PostModel> Get()
        {
            var posts = this.data.All().Select(PostModel.FromPost);
            return posts;
        }

        public HttpResponseMessage Post([FromBody]PostModel value)
        {
            var post = value.CreatePost();
            this.data.Add(post);

            var message = this.Request.CreateResponse(HttpStatusCode.Created);
            message.Headers.Location = new Uri(this.Request.RequestUri + post.PostId.ToString(CultureInfo.InvariantCulture));
            return message;
        }

        public void Put(int id, [FromBody]PostModel value)
        {
            var post = this.data.Get(id);
            value.UpdatePost(post);
        }

        public void Delete(int id)
        {
            this.data.Delete(id);
        }
    }
}