using System.Text;
using System.Text.Json;

namespace TranslationKeysTest.Models;

public class Country
{
    public Guid Id { get; init; }
    public JsonDocument Name { get; protected set; }
    public string Code { get; protected set; } = string.Empty;

    private Country()
    {
    }

    public static async Task<Country> CreateAsync(string code, TranslationObject name)
    {
        using var stream =
            new MemoryStream(Encoding.ASCII.GetBytes(JsonSerializer.Serialize(name, JsonOptions.Default)));
        var document = await JsonDocument.ParseAsync(stream);
        return new Country
        {
            Id = Guid.NewGuid(),
            Code = code,
            Name = document
        };
    }
}