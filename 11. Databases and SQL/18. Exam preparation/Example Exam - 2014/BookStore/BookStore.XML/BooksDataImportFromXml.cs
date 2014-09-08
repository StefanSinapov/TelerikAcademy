namespace BookStore.XML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Data;
    using Models;

    public class BooksDataImportFromXml
    {
        private readonly IBookStoreContext bookStoreContext;

        public BooksDataImportFromXml(IBookStoreContext bookStoreContext)
        {
            this.bookStoreContext = bookStoreContext;
        }

        public void Import(string filePath)
        {
            var booksXml = XElement.Load(filePath).Elements("book");

            foreach (var bookXml in booksXml)
            {
                var book = new Book();

                var titleXml = bookXml.Element("title");
                if (titleXml != null)
                {
                    var bookTitle = titleXml.Value;
                    book.Title = bookTitle;
                }


                var authors = GetAuthorsIfExists(bookXml);
                foreach (var author in authors)
                {
                    book.Authors.Add(author);
                }

                var webSite = bookXml.Element("web-site");
                if (webSite != null)
                {
                    book.WebSite = webSite.Value;
                }

                var reviewsCollection = GetReviewsIfExists(bookXml);
                foreach (var review in reviewsCollection)
                {
                    book.Reviews.Add(review);
                }

                var isbnXml = bookXml.Element("isbn");
                if (isbnXml != null)
                {
                    book.Isbn = isbnXml.Value;
                }

                var priceXml = bookXml.Element("price");
                if (priceXml != null)
                {
                    book.Price = decimal.Parse(priceXml.Value);
                }

                this.bookStoreContext.Books.Add(book);
                this.bookStoreContext.SaveChanges();
            }
        }

        private IEnumerable<Review> GetReviewsIfExists(XElement bookXml)
        {
            var reviewsCollection = new HashSet<Review>();
            var reviewsXml = bookXml.Element("reviews");
            if (reviewsXml != null)
            {
                foreach (var reviewXElement in reviewsXml.Elements("review"))
                {
                    var review = new Review();
                    this.SetAuthor(reviewXElement, review);
                    this.SetDateOfCreation(reviewXElement, review);
                    this.SetContent(reviewXElement, review);
                    reviewsCollection.Add(review);
                }
            }
            return reviewsCollection;
        }

        private void SetContent(XElement reviewXElement, Review review)
        {
            review.Content = reviewXElement.Value.Trim();
        }

        private void SetDateOfCreation(XElement reviewXElement, Review review)
        {
            var dateAttribute = reviewXElement.Attribute("date");
            if (dateAttribute != null)
            {
                review.DateOfCreation = DateTime.Parse(dateAttribute.Value);
            }
            else
            {
                review.DateOfCreation = DateTime.Now;
            }
        }

        private void SetAuthor(XElement reviewXElement, Review review)
        {
            var authorAttribute = reviewXElement.Attribute("author");
            if (authorAttribute != null)
            {
                var author = this.GetOrCreateAuthor(authorAttribute.Value);
                review.Author = author;
            }
        }

        private IEnumerable<Author> GetAuthorsIfExists(XElement bookXml)
        {
            var authors = new HashSet<Author>();
            if (bookXml.Element("authors") != null)
            {
                foreach (var author in bookXml.Elements("author"))
                {
                    var autor = GetOrCreateAuthor(author.Value);
                    authors.Add(autor);
                }
            }
            return authors;
        }

        private Author GetOrCreateAuthor(string authorName)
        {
            var author = this.bookStoreContext.Authors.FirstOrDefault(a => a.Name == authorName);

            if (author == null)
            {
                author = new Author
                {
                    Name = authorName
                };
            }

            return author;
        }
    }
}