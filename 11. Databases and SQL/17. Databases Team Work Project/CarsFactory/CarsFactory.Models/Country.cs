namespace CarsFactory.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
