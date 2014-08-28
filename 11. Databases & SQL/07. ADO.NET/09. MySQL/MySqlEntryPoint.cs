namespace _09.MySQL
{
    using System;
    using System.Configuration;
    using MySql.Data.MySqlClient;

    class MySqlEntryPoint
    {
        private static string connectionString;
        private static MySqlConnection mySqlDbConnection;

        static void Main()
        {
            // NOTE: Please change the password in connection string to fit your MySql password

            ConnectToMySqlDatabase();

            AddTenBooksToLibrary();
            ListingAllBooks();
            FindBooksByName("Potter 5");
            DeleteAllRecords();

            DisconectFromDatabase();

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
        }

        private static void AddBook(Book book)
        {
            

            var title = book.Title;
            var author = book.Author;
            var publishDate = book.PublishDate;
            var isbn = book.ISBN;

            var mySqlCommand = new MySqlCommand(@"INSERT INTO Books (Title, Author, PublishDate, ISBN)
                                                       VALUES (@title, @author, @publishDate, @isbn)", mySqlDbConnection);

            mySqlCommand.Parameters.AddWithValue("@title", title);
            mySqlCommand.Parameters.AddWithValue("@author", author);
            mySqlCommand.Parameters.AddWithValue("@publishDate", publishDate);
            mySqlCommand.Parameters.AddWithValue("@isbn", isbn);

            var queryResult = mySqlCommand.ExecuteNonQuery();
            mySqlCommand.Parameters.Clear();

            Console.WriteLine("     ({0} book(s) added.)", queryResult);
        }

        private static void ListingAllBooks()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Listing all books: ");
            Console.ResetColor();

            var mySqlCommand = new MySqlCommand(
                                                    @"SELECT Title, Author, PublishDate, ISBN FROM Books", 
                                                    mySqlDbConnection);

            using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
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

            var mySqlCommand = new MySqlCommand(@"DELETE FROM Books WHERE BookId > 0", mySqlDbConnection);

            var queryResult = mySqlCommand.ExecuteNonQuery();

            Console.WriteLine("    ({0} books(s) deleted)\n", queryResult);
        }

        private static void ConnectToMySqlDatabase()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString;
            mySqlDbConnection = new MySqlConnection(connectionString);
            mySqlDbConnection.Open();
        }

        private static void FindBooksByName(string substring)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nFinding books by name '{0}':", substring);
            Console.ResetColor();

            var mySqlCommand = new MySqlCommand(@"SELECT Title, Author, PublishDate, ISBN
                                                       FROM Books
                                                       WHERE LOCATE(@substring, Title)", mySqlDbConnection);

            mySqlCommand.Parameters.AddWithValue("@substring", substring);

            using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
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
            if (mySqlDbConnection != null)
            {
                mySqlDbConnection.Close();
            }
        }
    }
}
