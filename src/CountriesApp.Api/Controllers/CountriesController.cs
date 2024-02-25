using CountriesApp.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CountriesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ICountriesService _countriesService;

    public CountriesController(ICountriesService countriesService)
    {
        _countriesService = countriesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCountries()
    {
        var countries = await _countriesService.GetCountries();

        return Ok(countries);
    }
}
