using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace PAW2.Models.ViewModels
{
    public class CatalogTaskViewModel
    {
        [JsonPropertyName("id")]
        public decimal Id { get; set; }

        [JsonPropertyName("taskId")]
        public decimal? TaskId { get; set; }

        [JsonPropertyName("taskType")]
        public decimal? TaskType { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("status")]
        public decimal? Status { get; set; }

        [JsonPropertyName("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [JsonPropertyName("createdBy")]
        public string? CreatedBy { get; set; }

        [JsonPropertyName("modifiedDate")]
        public DateTime? ModifiedDate { get; set; }

        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; }
    }
}
