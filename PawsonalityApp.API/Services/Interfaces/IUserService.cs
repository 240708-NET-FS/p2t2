using Microsoft.AspNetCore.Identity;

namespace PawsonalityApp.API.Services;

public interface IUserService
{

    Task<IdentityUser> GetUserByUsername(string username);

    Task<ICollection<IdentityUser>> GetAllUsers();
}