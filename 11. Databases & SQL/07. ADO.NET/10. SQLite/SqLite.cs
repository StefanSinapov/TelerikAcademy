namespace _10.SQLite
{
    using System;
    using System.Configuration;
    using System.Data.SQLite;

    class SqLite
    {
        private static string connectionString;
        private static SQLiteConnection sqLiteDbConnection;

        static void Main()
        {

            try
            {
                ConnectToSqLiteDatabase();

                AddTenBooksToLibrary();
                ListingAllBooks();
                FindBooksByName("Potter 5");
                DeleteAllRecords();
            }
            finally
            {
                DisconectFromDatabase();
            }

        }

        private static void AddTenBooksToLibrary()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Adding books: ");
            Console.ResetColor();
            for (int i = 0; i < 10; i++)
            {
                var book = new Book
                {
                    Title = string.Format("Harry Potter {0}", i),
                    Author = "J. K. Rowling",
                    PublishDate = new DateTime(2000 + i, 05, 05),
                    ISBN = "1233-333000-122"
                };
                AddBook(book);
            }
            Console.WriteLine();
        }

        private static void AddBook(Book book)
        {


            var title = book.Title;
            var author = book.Author;
            var publishDate = book.PublishDate;
            var isbn = book.ISBN;

            var sqLiteCommand = new SQLiteCommand(@"INSERT INTO Books (Title, Author, PublishDate, ISBN)
                                                       VALUES (@title, @author, @publishDate, @isbn)", sqLiteDbConnection);

            sqLiteCommand.Parameters.AddWithValue("@title", title);
            sqLiteCommand.Parameters.AddWithValue("@author", author);
            sqLiteCommand.Parameters.AddWithValue("@publishDate", publishDate);
            sqLiteCommand.Parameters.AddWithValue("@isbn", isbn);

            var queryResult = sqLiteCommand.ExecuteNonQuery();
            sqLiteCommand.Parameters.Clear();

            Console.WriteLine("     ({0} book(s) added.)", queryResult);
        }

        private static void ListingAllBooks()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Listing all books: ");
            Console.ResetColor();

            var sqLiteCommand = new SQLiteCommand(
                                                    @"SELECT Title, Author, PublishDate, ISBN FROM Books",
                                                    sqLiteDbConnection);

            using (SQLiteDataReader reader = sqLiteCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var title = reader["Title"].ToString();
                    var author = reader["Author"].ToString();
                    var publishDate = (DateTime)reader["PublishDate"];
                    var isbn = reader["ISBN"].ToString();

                    var book = new Book
                    {
                        Title = title,
                        Author = author,
                        PublishDate = publishDate,
                        ISBN = isbn
                    };

                    Console.WriteLine(book);
                }
            }
        }

        private static void DeleteAllRecords()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Deleting all books: ");
            Console.ResetColor();

            var sqLiteCommand = new SQLiteCommand(@"DELETE FROM Books WHERE BookId > 0", sqLiteDbConnection);

            var queryResult = sqLiteCommand.ExecuteNonQuery();

            Console.WriteLine("    ({0} books(s) deleted)\n", queryResult);
        }

        private static void ConnectToSqLiteDatabase()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SQLiteLibrary"].ConnectionString;
            sqLiteDbConnection = new SQLiteConnection(connectionString);
            sqLiteDbConnection.Open();
        }

        private static void FindBooksByName(string substring)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nFinding books by name '{0}':", substring);
            Console.ResetColor();

            var sqLiteCommand = new SQLiteCommand(@"SELECT Title, Author, PublishDate, ISBN
                                                       FROM Books
                                                       WHERE CHARINDEX(@substring, Title)", sqLiteDbConnection);

            sqLiteCommand.Parameters.AddWithValue("@substring", substring);

            using (var reader = sqLiteCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var title = reader["Title"].ToString();
                    var author = reader["Author"].ToString();
                    var publishDate = (DateTime)reader["PublishDate"];
                    var isbn = reader["ISBN"].ToString();

                    var book = new Book
                    {
                        Title = title,
                        Author = author,
                        PublishDate = publishDate,
                        ISBN = isbn
                    };

                    Console.WriteLine(book);
                }
            }
        }

        private static void DisconectFromDatabase()
        {
            if (sqLiteDbConnection != null)
            {
                sqLiteDbConnection.Close();
            }
        }
    }
}
