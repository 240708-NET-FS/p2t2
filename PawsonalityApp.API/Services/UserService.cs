
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PawsonalityApp.API.Exceptions;

namespace PawsonalityApp.API.Services;

public class UserService : IUserService
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ICollection<IdentityUser>> GetAllUsers()
    {
        return await _userManager.Users.ToListAsync();
    }

    public async Task<IdentityUser> GetUserByUsername(string username)
    {
        IdentityUser? user = await _userManager.FindByNameAsync(username);

        if(user == null)
        {
            throw new InvalidUserException($"User with username {username} does not exist.");
        }

        return user;
    }
}