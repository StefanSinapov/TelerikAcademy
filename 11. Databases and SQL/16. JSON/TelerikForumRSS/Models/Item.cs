namespace TelerikForumRSS.Models
{
    using System;
    using Newtonsoft.Json;

    public class Item
    {
        
        public Item()
        {
            
        }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("pubDate")]
        public DateTime PubDate { get; set; }

        public override string ToString()
        {
            return string.Format("Title: {0}, PublishDate [{1}]", this.Title, this.PubDate.ToShortDateString());
        }
    }
}