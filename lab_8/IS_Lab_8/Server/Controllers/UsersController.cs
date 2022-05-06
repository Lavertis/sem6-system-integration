using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("authenticate")]
    public ActionResult<AuthenticationResponse> Authenticate(AuthenticationRequest request)
    {
        var user = _userService.Authenticate(request);
        if (user == null)
            return BadRequest(new {message = "Username or password is incorrect"});

        return Ok(user);
    }
}