namespace BugLogger.WebAPI.Tests.Fakes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Contracts;
    using Models;

    public class BugFakeRepository : IBugRepository
    {

        public BugFakeRepository()
        {
            this.Entities = new List<Bug>();
        }

        public bool IsSaveChangedCalled { get; set; }

        private IList<Bug> Entities { get; set; }

        public IQueryable<Bug> All()
        {
            return this.Entities.AsQueryable();
        }

        public Bug Find(int id)
        {
            return this.Entities.FirstOrDefault(b => b.Id == id);
        }

        public void Add(Bug entity)
        {
            this.Entities.Add(entity);
        }

        public void Update(Bug entity)
        {
            var bug = this.Find(entity.Id);
            if (bug == null)
            {
                return;
            }

            bug = entity;
        }

        public void Delete(Bug entity)
        {
            this.Delete(entity.Id);
        }

        public void Delete(int id)
        {
            var bug = this.Find(id);
            if (bug != null)
            {
                this.Entities.Remove(bug);
            }
        }

        public IQueryable<Bug> GetAllByStatus(BugStatus status)
        {
            return this.Entities.AsQueryable().Where(b => b.Status == status);
        }

        public IQueryable<Bug> GetAllFromDate(DateTime fromDate)
        {
            return this.GetAllInDateRange(fromDate, DateTime.MaxValue);
        }

        public IQueryable<Bug> GetAllToDate(DateTime toDate)
        {
            return this.GetAllInDateRange(DateTime.MinValue, toDate);
        }

        public IQueryable<Bug> GetAllInDateRange(DateTime fromDate, DateTime toDate)
        {
            return this.Entities.AsQueryable().Where(b => b.LogDate >= fromDate && b.LogDate <= toDate);
        }

        public void Detach(Bug entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            this.IsSaveChangedCalled = true;
        }
    }
}