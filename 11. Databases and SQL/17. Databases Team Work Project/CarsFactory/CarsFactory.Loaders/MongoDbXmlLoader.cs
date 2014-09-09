namespace CarsFactory.Loaders
{
    using System.Globalization;
    using System.Linq;
    using Data;
    using global::MongoDB.Bson;
    using global::MongoDB.Driver.Builders;
    using Models;
    using MongoDB.Data;

    public class MongoDbXmlLoader
    {
        private readonly MongoDbContext mongoDbContext;

        public MongoDbXmlLoader(MongoDbContext mongoDbContext)
        {
            this.mongoDbContext = mongoDbContext;
        }

        public void UploadManufacturer(Manufacturer manufacturer)
        {
            bool alreadyExists = this.mongoDbContext.Manufacturers
                                                        .Find(Query<MongoDb.Models.Manufacturer>
                                                            .EQ(e => e.Name, manufacturer.Name))
                                                        .Any();
            if (alreadyExists)
            {
                return;
            }

            this.mongoDbContext.Manufacturers
                                    .Insert(new MongoDb.Models.Manufacturer(manufacturer.Id, manufacturer.Name));
        }

        public void UploadMonth(Month month)
        {
            var alreadyExists = this.mongoDbContext.Months
                            .Find(Query<Month>.EQ(m => m.Name, month.Name))
                            .Any();
            if (alreadyExists)
            {
                return;
            }

            this.mongoDbContext.Months.Insert(
                new MongoDb.Models.Month(month.MonthId, month.Name));
        }

        public void UploadExpense(Expense expense)
        {
            var alreadyExists = this.mongoDbContext.Expenses
                                .Find(Query<Expense>.EQ(e => e.ExpenseId, expense.ExpenseId))
                                .Any();
            if (alreadyExists)
            {
                return;
            }

            this.mongoDbContext.Expenses.Insert(new MongoDb.Models.Expense
            {
                MonthId = expense.MonthId,
                ExpenseId = expense.ExpenseId,
                ManufacturerId = expense.ManufacturerId,
                Value = expense.Value
            });
        }
    }
}