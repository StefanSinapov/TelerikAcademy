namespace BookStore.Data
{
    using System.Data.Entity;
    using Models;

    public class BookStoreContext : DbContext, IBookStoreContext
    {
        public BookStoreContext()
            : base(ConnectionStrings.Default.MsSql)
        {
//            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookStoreDbContext, Configuration>());
        }


        public IDbSet<Book> Books { get; set; }
        public IDbSet<Author> Authors { get; set; }
        public IDbSet<Review> Reviews { get; set; }
    }
}