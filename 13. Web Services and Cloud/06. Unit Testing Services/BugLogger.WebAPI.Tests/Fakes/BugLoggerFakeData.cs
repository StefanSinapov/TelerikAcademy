namespace BugLogger.WebAPI.Tests.Fakes
{
    using Data.Contracts;

    public class BugLoggerFakeData : IBugLoggerData
    {
        private BugFakeRepository bugs;

        public BugLoggerFakeData()
        {
            bugs = new BugFakeRepository();
        }

        public bool IsSaveChangesCalled { get; set; }

        public IBugRepository Bugs
        {
            get { return this.bugs; }
        }

        public int SaveChanges()
        {
            this.IsSaveChangesCalled = true;
            return 1;
        }
    }
}