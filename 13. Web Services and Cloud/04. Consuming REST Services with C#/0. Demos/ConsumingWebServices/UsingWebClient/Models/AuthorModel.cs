using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsingWebClient.Models;

namespace UsingWebClient.Models
{
    public class AuthorModel
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }

    public class AuthorDetails:AuthorModel
    {
        public IEnumerable<BookModel> Books { get; set; }
    }

    public class NewAuthorModel
    {

        public string Name { get; set; }
    }
}