
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PawsonalityApp.API.Exceptions;

namespace PawsonalityApp.API.Services;

public class UserService : IUserService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public UserService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IdentityResult> CreateUser(IdentityUser newUser)
    {
        return await _userManager.CreateAsync(newUser);
    }

    public async Task<IdentityUser> DeleteUser(string ID)
    {
        IdentityUser? identityUser = await _userManager.FindByIdAsync(ID);

        if (identityUser == null)
        {
            throw new InvalidUserException($"User with ID {ID} does not exist.");
        }

        IdentityResult result = await _userManager.DeleteAsync(identityUser);

        return result.Succeeded ? identityUser : throw new InvalidUserException("Something went wrong when deleting user.");
    }

    public async Task<ICollection<IdentityUser>> GetAllUsers()
    {
        return await _userManager.Users.ToListAsync();
    }

    public async Task<IdentityUser> GetUserByID(string userID)
    {
        IdentityUser? user = await _userManager.FindByIdAsync(userID);

        if (user == null)
        {
            throw new InvalidUserException($"User with ID {userID} does not exist.");
        }

        return user;
    }

    public async Task<SignInResult> LoginUser(string username, string password)
    {
        return await _signInManager.PasswordSignInAsync(username, password, false, false);
    }

    public async Task LogoutUser()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<IdentityUser> UpdateUser(string ID, IdentityUser userToUpdate)
    {
        IdentityUser? user = await _userManager.FindByIdAsync(ID);

        if(user == null) 
        {
            throw new InvalidUserException($"User with ID {ID} does not exist.");
        }

        user.UserName = userToUpdate.UserName;

        var result = await _userManager.UpdateAsync(user);

        return result.Succeeded ? user : throw new InvalidUserException($"An Error has occurred when updating user with ID {ID}");
    }


}