using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsingWebClient.Models
{
    public class BookModel
    {
        public long Id { get; set; }

        public string Title { get; set; }
    }

    public class BookDetails : UsingWebClient.Models.BookModel
    {
        public string Author { get; set; }
        public string Genre { get; set; }
    }

    public class NewBookModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}