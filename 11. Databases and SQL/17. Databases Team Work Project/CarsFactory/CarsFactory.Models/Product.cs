namespace CarsFactory.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [DataContract]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string Model { get; set; }

        [DataMember]
        public int HorsePower { get; set; }

        [DataMember]
        public int ReleaseYear { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }

        [ForeignKey("CarType")]
        public int CarTypeId { get; set; }

        [ForeignKey("EngineType")]
        public int EngineTypeId { get; set; }

        [DataMember]
        public virtual Manufacturer Manufacturer { get; set; }

        [DataMember]
        public virtual EngineType EngineType { get; set; }

        [DataMember]
        public virtual CarType CarType { get; set; }
    }
}
