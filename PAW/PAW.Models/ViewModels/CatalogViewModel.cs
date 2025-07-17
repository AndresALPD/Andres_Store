using System;
using System.Text.Json.Serialization;

namespace PAW2.Models.ViewModels
{
    public class CatalogViewModel
    {
        [JsonPropertyName("identifier")]
        public int Identifier { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("sku")]
        public string? Sku { get; set; }

        [JsonPropertyName("rating")]
        public decimal? Rating { get; set; }

        [JsonPropertyName("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [JsonPropertyName("createdBy")]
        public string? CreatedBy { get; set; }
    }
}
