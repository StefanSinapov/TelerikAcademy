using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsingWebClient.Models
{
    public class GenreModel
    {
        public long Id { get; set; }

        public string Genre { get; set; }
    }

    public class GenreDetails : UsingWebClient.Models.GenreModel
    {
        public IEnumerable<UsingWebClient.Models.BookModel> Books { get; set; }
    }

    public class NewGenreModel
    {
        public string Genre { get; set; }
    }
}