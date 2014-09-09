namespace CarsFactory.SQLite.Data
{
    public class ProductRejection
    {
        public long ID { get; set; }

        public string Model { get; set; }

        public long RejectionCount { get; set; }
    }
}