namespace Cars.Models.Mappings
{
    using Newtonsoft.Json;

    public class JsonDealer
    {
        public JsonDealer()
        {
            
        }
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }
    }
}