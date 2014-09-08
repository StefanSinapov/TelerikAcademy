namespace BookStore.XML
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    using Models;

    public class ReviewsSearchResultsXmlExporter
    {
        private const string DateTimeFormat = "d-MMM-yyyy";
        private readonly DateTimeFormatInfo usDtfi = new CultureInfo("en-US", false).DateTimeFormat;

        public void Export(ICollection<ICollection<Review>> resultSets, string pathToSaveXml)
        {
            var searchResultXml = new XElement("search-results");

            foreach (var resultSet in resultSets)
            {
                var resultSetXml = new XElement("result-set");

                foreach (var review in resultSet)
                {
                    var reviewXml = new XElement("review",
                        new XElement("date", review.DateOfCreation.ToString(DateTimeFormat, usDtfi)),
                        new XElement("content", review.Content));

                    var reviewBook = review.Book;
                    var bookXml = new XElement("book",
                        new XElement("title", reviewBook.Title));

                    this.AddAuthorsXElement(reviewBook, bookXml);
                    this.AddIsbnXElement(reviewBook, bookXml);
                    this.AddWebSiteXElement(reviewBook, bookXml);

                    reviewXml.Add(bookXml);
                    resultSetXml.Add(reviewXml);
                }

                searchResultXml.Add(resultSetXml);
            }

            searchResultXml.Save(new StreamWriter(pathToSaveXml, false, Encoding.UTF8));
        }

        private void AddWebSiteXElement(Book reviewBook, XElement bookXml)
        {
            if (!string.IsNullOrEmpty(reviewBook.WebSite))
            {
                var webSiteXelement = new XElement("url", reviewBook.WebSite);
                bookXml.Add(webSiteXelement);
            }

        }

        private void AddIsbnXElement(Book reviewBook, XElement bookXml)
        {
            if (!string.IsNullOrEmpty(reviewBook.Isbn))
            {
                var isbnXelement = new XElement("isbn", reviewBook.Isbn);
                bookXml.Add(isbnXelement);
            }
        }

        private void AddAuthorsXElement(Book reviewBook, XElement bookXml)
        {
            if (reviewBook.Authors.Any())
            {
                var authors = reviewBook.Authors.Select(a => a.Name).OrderBy(a => a);
                var authorXElement = new XElement("autor", string.Join(", ", authors));
                bookXml.Add(authorXElement);
            }
        }
    }
}