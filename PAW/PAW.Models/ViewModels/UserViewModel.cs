using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace PAW2.Models.ViewModels
{
    public class UserViewModel
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("passwordHash")]
        public string? PasswordHash { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("lastModified")]
        public DateTime? LastModified { get; set; }

        [JsonPropertyName("modifiedBy")]
        public string? ModifiedBy { get; set; }
    }
}

