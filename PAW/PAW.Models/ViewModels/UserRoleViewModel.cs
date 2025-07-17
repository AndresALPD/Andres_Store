using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace PAW2.Models.ViewModels
{
    public class UserRoleViewModel
    {
        [JsonPropertyName("id")]
        public decimal Id { get; set; }

        [JsonPropertyName("userID")]
        public decimal? UserId { get; set; }

        [JsonPropertyName("roldID")]
        public decimal? RoldId { get; set; }
    }
}
