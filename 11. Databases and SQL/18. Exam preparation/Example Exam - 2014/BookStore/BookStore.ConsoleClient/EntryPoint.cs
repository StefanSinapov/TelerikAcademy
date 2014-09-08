namespace BookStore.ConsoleClient
{
    using System;
    using System.Linq;
    using Data;
    using XML;

    class EntryPoint
    {
        private const string BooksImportXmlFilePath = "../../../input/complex-books.xml";
        private const string ReviewsQueriesXmlFilePath = "../../../input/reviews-queries.xml";
        private const string SearchResultExportXmlFilePath = "../../../output/reviews-search-results.xml";
        private const string SearchResultExportJsonFilePath = "";

        private static BookStoreContext bookStoreContext = new BookStoreContext();
        private static BooksDataImportFromXml booksDataImport = new BooksDataImportFromXml(bookStoreContext);
        private static ReviewQueriesXmlParser reviewQueriesXmlParser = new ReviewQueriesXmlParser(bookStoreContext);
        private static ReviewsSearchResultsXmlExporter reviewsSearchResultsXmlExporter = new ReviewsSearchResultsXmlExporter();

        static void Main()
        {
            using (bookStoreContext)
            {
                Console.WriteLine("Loading...");
                booksDataImport.Import(BooksImportXmlFilePath);
                var reviewsResult = reviewQueriesXmlParser.GetReviews(ReviewsQueriesXmlFilePath);
                reviewsSearchResultsXmlExporter.Export(reviewsResult, SearchResultExportXmlFilePath);
            }
        }
    }
}
