namespace CarsFactory.MongoDb.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class Expense
    {
        [BsonConstructor]
        public Expense()
        {
        }

        [BsonConstructor]
        public Expense(int expenseId, decimal value, int monthId, int manufacturerId)
        {
            this.ExpenseId = expenseId;
            this.Value = value;
            this.MonthId = monthId;
            this.ManufacturerId = manufacturerId;
        }

        [BsonId]
        public BsonObjectId Id { get; set; }

        public int ExpenseId { get; set; }

        public decimal Value { get; set; }

        public int MonthId { get; set; }

        public int ManufacturerId { get; set; }
    }
}