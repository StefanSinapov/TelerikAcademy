namespace AspNetWebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    public class StringsController : ApiController
    {
        // Note that this field is static
        private static readonly IList<string> Strings = new List<string> { "String 1", "String 2", };

        // GET api/strings
        [HttpGet]
        public IEnumerable<string> All()
        {
            return Strings;
        }

        // GET api/strings/5
        public string Get(int id)
        {
            return Strings[id];
        }

        // POST api/strings
        public void Post([FromBody]string value)
        {
            Strings.Add(value);
        }

        // PUT api/strings/5
        public void Put(int id, [FromBody]string value)
        {
            Strings[id] = value;
        }

        // DELETE api/strings/5
        public void Delete(int id)
        {
            Strings.RemoveAt(id);
        }
    }
}
