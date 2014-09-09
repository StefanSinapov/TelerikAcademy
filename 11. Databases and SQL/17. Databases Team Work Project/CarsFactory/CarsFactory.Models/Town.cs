namespace CarsFactory.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Town
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
