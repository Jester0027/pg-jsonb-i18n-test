using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranslationKeysTest.Data;
using TranslationKeysTest.Models;

namespace TranslationKeysTest.Controllers;

[ApiController]
[Route("countries")]
public class CountriesController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public CountriesController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromHeader(Name = "x-locale")] string? locale = null
    )
    {
        locale ??= "fr";
        var result = await _dbContext.Countries
            .AsNoTracking()
            .Select(x => new CountryViewModel
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name.RootElement.GetProperty(locale).GetString() ??
                       x.Name.RootElement.GetProperty("fr").GetString()!
            })
            .ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateCountryViewModel model,
        [FromHeader(Name = "x-locale")] string? locale = null
    )
    {
        locale ??= "fr";
        var country = await Country.CreateAsync(model.Code, model.Name);
        await _dbContext.Countries.AddAsync(country);
        await _dbContext.SaveChangesAsync();
        return new ObjectResult(CountryViewModel.FromCountry(country, locale)) {StatusCode = 201};
    }
}