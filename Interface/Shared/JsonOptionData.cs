using System.Text.Json;

namespace Interface.Shared;

public struct JsonOptionData
{
    public static JsonSerializerOptions Default { get; } = new()
    {
        PropertyNameCaseInsensitive = true
    };
}