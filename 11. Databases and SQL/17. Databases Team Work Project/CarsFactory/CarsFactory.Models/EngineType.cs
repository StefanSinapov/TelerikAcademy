namespace CarsFactory.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    public class EngineType
    {
        [Key]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}