using System.Text.Json.Serialization;

namespace Server.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    [JsonIgnore] public string Password { get; set; } = string.Empty;
    public List<Role> Roles { get; set; } = new();

    public override string ToString() => $"Id: {Id}, Username: {Username}";
}