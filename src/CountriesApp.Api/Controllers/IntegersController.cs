using CountriesApp.Application.Contracts;
using CountriesApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CountriesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IntegersController : ControllerBase
{
    private readonly IIntegersService _integersService;

    public IntegersController(IIntegersService integersService)
    {
        _integersService = integersService;
    }

    [HttpPost]
    public async Task<IActionResult> GetSecondLargest([FromBody] RequestObj request)
    {
        var secondLargest = await _integersService.GetSecondLargest(request);

        return Ok(new { SecondLargestNumber = secondLargest });
    }
}