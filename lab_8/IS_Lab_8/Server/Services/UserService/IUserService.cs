using Server.Entities;
using Server.Models;

namespace Server.Services.UserService;

public interface IUserService
{
    AuthenticationResponse? Authenticate(AuthenticationRequest request);
    IEnumerable<User> GetAllUsers();
    User? GetUserByUsername(string username);
    User? GetUserById(int id);
    int GetUserCount();
}