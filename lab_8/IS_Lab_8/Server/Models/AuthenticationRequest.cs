using System.ComponentModel.DataAnnotations;

namespace Server.Models;

public class AuthenticationRequest
{
    public AuthenticationRequest(string username, string password)
    {
        Username = username;
        Password = password;
    }

    [Required] public string Username { get; set; }

    [Required] public string Password { get; set; }
}