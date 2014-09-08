namespace Cars.Models.Mappings
{
    using Newtonsoft.Json;

    public class JsonCar
    {
        public JsonCar()
        {
            
        }

        [JsonProperty("Year")]
        public int Year { get; set; }

        [JsonProperty("TransmissionType")]
        public int TransmissionType { get; set; }

        [JsonProperty("ManufacturerName")]
        public string ManufacturerName { get; set; }

        [JsonProperty("Model")]
        public string Model { get; set; }

        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [JsonProperty("Dealer")]
        public JsonDealer Dealer { get; set; }
    }
}
