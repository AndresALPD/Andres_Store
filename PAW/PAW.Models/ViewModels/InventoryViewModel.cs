using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace PAW2.Models.ViewModels
{
    public class InventoryViewModel
    {
        [JsonPropertyName("inventoryId")]
        public int InventoryId { get; set; }

        [JsonPropertyName("unitPrice")]
        public decimal? UnitPrice { get; set; }

        [JsonPropertyName("dateAdded")]
        public DateTime? DateAdded { get; set; }

        [JsonPropertyName("lastUpdated")]
        public DateTime? LastUpdated { get; set; }

        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; }
    }
}
