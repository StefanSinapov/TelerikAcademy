namespace BunniesCraft.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AirCraft
    {
        private ICollection<Bunny> bunnies;

        public AirCraft()
        {
            this.bunnies = new HashSet<Bunny>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Model { get; set; }

        public virtual ICollection<Bunny> Bunnies
        {
            get { return this.bunnies; }
            set { this.bunnies = value; }
        }
    }
}
