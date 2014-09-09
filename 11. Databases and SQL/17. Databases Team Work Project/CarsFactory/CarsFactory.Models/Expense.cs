namespace CarsFactory.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }

        public decimal Value { get; set; }

        public int MonthId { get; set; }

        public virtual Month Month { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
