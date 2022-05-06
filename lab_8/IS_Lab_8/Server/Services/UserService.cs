using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Server.Entities;
using Server.Models;

namespace Server.Services;

public class UserService : IUserService
{
    private static List<User> _users = new()
    {
        new User
        {
            Id = 1,
            Username = "Andrzej",
            Password = "Andrzej",
            Roles = new List<Role> {new("admin"), new("user")}
        },
        new User
        {
            Id = 2,
            Username = "Piotrek",
            Password = "Piotrek",
            Roles = new List<Role> {new("number"), new("user")}
        },
        new User
        {
            Id = 3,
            Username = "Ania",
            Password = "Ania",
            Roles = new List<Role> {new("user")}
        }
    };

    private IConfiguration _configuration;

    public UserService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public AuthenticationResponse? Authenticate(AuthenticationRequest request)
    {
        var user = GetUserByUsername(request.Username);
        if (user == null || user.Password != request.Password)
        {
            return null;
        }

        var token = GenerateJwtToken(user);
        return new AuthenticationResponse(user, token);
    }

    public User? GetUserById(int id)
    {
        return _users.FirstOrDefault(x => x.Id == id);
    }

    public User? GetUserByUsername(string username)
    {
        return _users.FirstOrDefault(x => x.Username == username);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _users;
    }

    private string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
        var claims = new List<Claim>();
        claims.Add(new Claim("id", user.Id.ToString()));
        claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims.ToArray()),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            )
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}