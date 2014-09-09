namespace CarsFactory.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Sale
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Sum { get; set; }

        [ForeignKey("SalesReport")]
        public int SalesReportId { get; set; }

        public virtual SalesReport SalesReport { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

    }
}
