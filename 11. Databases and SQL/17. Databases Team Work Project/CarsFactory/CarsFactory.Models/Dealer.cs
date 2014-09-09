namespace CarsFactory.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Dealer
    {
        private ICollection<SalesReport> salesReports;

        public Dealer()
        {
            this.salesReports = new HashSet<SalesReport>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<SalesReport> SalesReports
        {
            get
            {
                return this.salesReports;
            }
            set
            {
                this.salesReports = value;
            }
        }
    }
}
