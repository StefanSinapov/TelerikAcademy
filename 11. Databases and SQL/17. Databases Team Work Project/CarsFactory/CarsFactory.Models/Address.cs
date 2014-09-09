namespace CarsFactory.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AddressText { get; set; }

        [ForeignKey("Town")]
        public int TownId { get; set; }

        public virtual Town Town { get; set; }

        public override string ToString()
        {
            return this.AddressText;
        }
    }
}
