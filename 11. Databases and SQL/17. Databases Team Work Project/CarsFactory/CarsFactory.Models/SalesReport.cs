namespace CarsFactory.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SalesReport
    {
        private ICollection<Sale> sales;

        public SalesReport()
        {
            this.sales = new HashSet<Sale>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime ReportDate { get; set; }

        public decimal TotalSum { get; set; }

        [ForeignKey("Dealer")]
        public int DealerId { get; set; }

        public virtual Dealer Dealer { get; set; }

        public virtual ICollection<Sale> Sales
        {
            get { return this.sales; }
            set { this.sales = value; }
        }
    }
}
