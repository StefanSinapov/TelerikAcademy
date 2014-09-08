namespace BookStore.XML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Data;
    using Models;

    public class ReviewQueriesXmlParser
    {
        private readonly IBookStoreContext bookStoreContext;

        public ReviewQueriesXmlParser(IBookStoreContext bookStoreContext)
        {
            this.bookStoreContext = bookStoreContext;
        }

        public ICollection<ICollection<Review>> GetReviews(string xmlFilePath)
        {
            var queriesXml = XElement.Load(xmlFilePath).Elements("query");

            var searchResult = new List<ICollection<Review>>();
            var resultSet = this.bookStoreContext.Reviews.AsQueryable();

            foreach (var queryXml in queriesXml)
            {
                var type = queryXml.Attribute("type").Value;

                if (type == "by-period")
                {
                    resultSet = this.MakeQueryByPeriod(queryXml, resultSet);
                }
                else if (type == "by-author")
                {
                    resultSet = this.MakeQueryByAuthor(queryXml, resultSet);
                }

                resultSet = this.SortQueryByDateAndContent(resultSet);

                searchResult.Add(resultSet.ToList());
            }

            return searchResult;
        }

        private IQueryable<Review> SortQueryByDateAndContent(IQueryable<Review> resultSet)
        {
            return resultSet.OrderBy(r => r.DateOfCreation)
                            .ThenBy(r => r.Content);
        }

        private IQueryable<Review> MakeQueryByAuthor(XElement queryXml, IQueryable<Review> resultSet)
        {
            var xElement = queryXml.Element("author");
            if (xElement != null)
            {
                var authorName = xElement.Value;
                resultSet = resultSet.Where(r => r.Author.Name == authorName);
            }
            return resultSet;
        }

        private IQueryable<Review> MakeQueryByPeriod(XElement queryXml, IQueryable<Review> resultSet)
        {
            var startDateXml = queryXml.Element("start-date");
            var endElement = queryXml.Element("end-date");

            if (startDateXml != null && endElement != null)
            {
                var startDate = DateTime.Parse(startDateXml.Value);
                var endDate = DateTime.Parse(endElement.Value);

                resultSet = resultSet.Where(r => startDate <= r.DateOfCreation && r.DateOfCreation <= endDate);
            }
            return resultSet;
        }
    }
}