using BugLogger.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugLogger.DataLayer.Migrations;

namespace BugLogger.DataLayer
{
    public class BugLoggerDbContext : DbContext
    {
        public BugLoggerDbContext()
            : base("BugLoggerDb")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<BugLoggerDbContext, Configuration>());
        }

        public virtual IDbSet<Bug> Bugs { get; set; }
    }
}
