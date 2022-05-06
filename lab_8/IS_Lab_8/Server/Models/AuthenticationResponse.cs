using Server.Entities;

namespace Server.Models;

public class AuthenticationResponse
{
    public AuthenticationResponse()
    {
    }

    public AuthenticationResponse(User user, string token)
    {
        Id = user.Id;
        Username = user.Username;
        Token = token;
    }

    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}