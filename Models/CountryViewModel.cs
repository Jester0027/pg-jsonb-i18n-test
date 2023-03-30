namespace TranslationKeysTest.Models;

public sealed record CountryViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;

    public CountryViewModel()
    {
    }

    public static CountryViewModel FromCountry(Country country, string locale)
    {
        return new CountryViewModel
        {
            Id = country.Id,
            Code = country.Code,
            Name = country.Name.RootElement.GetProperty(locale).GetString() ??
                   country.Name.RootElement.GetProperty("fr").GetString()!
        };
    }
}

public sealed record CreateCountryViewModel
{
    public TranslationObject Name { get; set; }
    public string Code { get; set; } = string.Empty;
}