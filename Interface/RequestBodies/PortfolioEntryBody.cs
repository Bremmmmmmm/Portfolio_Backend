using System.Text.Json.Serialization;

namespace Interface.RequestBodies;

public struct PortfolioEntryBody
{
    [JsonPropertyName("id")]public int Id { get; init; }
    [JsonPropertyName("title")]public string Title { get; set; }
    [JsonPropertyName("description")]public string Description { get; init; }
    [JsonPropertyName("mediaUrl")]public string MediaUrl { get; init; }
}