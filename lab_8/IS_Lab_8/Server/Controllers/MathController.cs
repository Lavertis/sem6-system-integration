using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Services.MathService;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MathController : ControllerBase
{
    private readonly IMathService _mathService;

    public MathController(IMathService mathService)
    {
        _mathService = mathService;
    }

    /// <summary>
    /// Returns random prime number in specified range. Only for users with role "number".
    /// </summary>
    [HttpGet("random-prime/min/{min:int}/max/{max:int}")]
    [Authorize(Roles = "number", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<int> GetRandomPrime(int min, int max)
    {
        return Ok(_mathService.GetRandomPrime(min, max));
    }
}