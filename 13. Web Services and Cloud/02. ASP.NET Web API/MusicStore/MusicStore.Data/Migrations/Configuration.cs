namespace MusicStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MusicStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MusicStoreDbContext context)
        {
           context.Songs.Add(new Song
           {
               Title = "Some Song",
               Genre = Genre.Pop,
               Year = new DateTime(2014, 01, 01)
           })
        }
    }
}
