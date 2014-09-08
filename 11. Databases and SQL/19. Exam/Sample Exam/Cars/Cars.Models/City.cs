namespace Cars.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class City
    {
        private ICollection<Dealer> dealers;

        public City()
        {
            this.dealers = new HashSet<Dealer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        public virtual ICollection<Dealer> Dealers
        {
            get { return this.dealers; }
            set { this.dealers = value; }
        } 
    }
}