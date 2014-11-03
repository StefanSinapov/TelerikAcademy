namespace FileSystem.Data
{
    using System.Data.Entity;

    using FileSystem.Common;
    using FileSystem.Data.Migrations;
    using FileSystem.Models;

    public class FileSysteDbContext : DbContext
    {
        public FileSysteDbContext()
            : base(ConnectionStrings.DefaultConnection)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FileSysteDbContext, Configuration>());
        }

        public IDbSet<FileContent> FileContents { get; set; }
    }
}