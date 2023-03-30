using System.Text.Json;
using System.Text.Json.Serialization;

namespace TranslationKeysTest;

public static class JsonOptions
{
    public static readonly JsonSerializerOptions Default = new JsonSerializerOptions()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
}