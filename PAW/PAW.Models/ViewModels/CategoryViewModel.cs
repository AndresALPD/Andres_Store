using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace PAW2.Models.ViewModels
{
    public class CategoryViewModel
    {
        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }

        [JsonPropertyName("categoryName")]
        public string? CategoryName { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("lastModified")]
        public DateTime? LastModified { get; set; }

        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; }
    }
}
