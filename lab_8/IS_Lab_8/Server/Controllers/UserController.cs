using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Entities;
using Server.Models;
using Server.Services.UserService;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Returns all users. Only for users with role "admin".
    /// </summary>
    [HttpGet]
    [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<IEnumerable<User>> GetAllUsers()
    {
        return Ok(_userService.GetAllUsers());
    }

    /// <summary>
    /// Returns user count. Only for users with role "user".
    /// </summary>
    [HttpGet("count")]
    [Authorize(Roles = "user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<int> GetUserCount()
    {
        return Ok(_userService.GetUserCount());
    }

    /// <summary>
    /// Returns access token after successful authentication.
    /// </summary>
    [HttpPost("authenticate")]
    public ActionResult<AuthenticationResponse> Authenticate(AuthenticationRequest request)
    {
        var authResponse = _userService.Authenticate(request);
        if (authResponse == null)
            return BadRequest(new {message = "Username or password is incorrect"});

        return Ok(authResponse);
    }
}