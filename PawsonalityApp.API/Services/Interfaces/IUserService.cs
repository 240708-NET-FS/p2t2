using Microsoft.AspNetCore.Identity;

namespace PawsonalityApp.API.Services;

public interface IUserService
{

    Task<IdentityResult> CreateUser(IdentityUser newUser);

    // Read
    Task<IdentityUser> GetUserByID(string userID);

    public Task<SignInResult> LoginUser(string username, string password);

    public Task LogoutUser();

    Task<ICollection<IdentityUser>> GetAllUsers();

    Task<IdentityUser> UpdateUser(string ID, IdentityUser userToUpdate);

    // Delete
    Task<IdentityUser> DeleteUser(string ID);
}