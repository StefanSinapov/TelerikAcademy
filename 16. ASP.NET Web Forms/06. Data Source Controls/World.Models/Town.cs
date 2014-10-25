namespace World.Models
{
    public class Town
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Population { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
