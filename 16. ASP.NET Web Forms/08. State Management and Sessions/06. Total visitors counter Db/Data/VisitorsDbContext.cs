namespace VisitorsCounter.Data
{
    using System.Data.Entity;

    public class VisitorsDbContext : DbContext
    {
        public VisitorsDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Visitor> Visitors { get; set; }
    }
}