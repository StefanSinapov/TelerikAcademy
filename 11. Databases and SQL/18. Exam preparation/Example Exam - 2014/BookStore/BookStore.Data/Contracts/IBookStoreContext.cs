namespace BookStore.Data
{
    using System.Data.Entity;
    using Models;

    public interface IBookStoreContext
    {
        IDbSet<Book> Books { get; set; }

        IDbSet<Author> Authors { get; set; }

        IDbSet<Review> Reviews { get; set; }

        int SaveChanges(); 
    }
}