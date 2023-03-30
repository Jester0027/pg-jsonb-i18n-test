namespace TranslationKeysTest.Models;

public sealed record TranslationObject
{
    public string Fr { get; set; } = string.Empty;
    public string? En { get; set; }
    public string? De { get; set; }
}