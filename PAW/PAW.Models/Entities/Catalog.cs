using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PAW.Models;

public partial class Catalog
{
    [JsonPropertyName("identifier")]
    public int Identifier { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;
    public DateTime ModifiedDatee { get; set; }
}
