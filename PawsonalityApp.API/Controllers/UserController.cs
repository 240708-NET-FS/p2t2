namespace Pawsonality.API.Controllers;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Pawsonality.API.Models;
using PawsonalityApp.API.Exceptions;
using PawsonalityApp.API.Services;

[ApiController]
[Route("api/answers")]
public class UserController : ControllerBase
{
    private readonly IUserService _userServices;

    public UserController(IUserService userService)
    {
        _userServices = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        ICollection<IdentityUser> users = await _userServices.GetAllUsers();

        if (users.IsNullOrEmpty())
        {
            return NotFound("No users found.");
        }

        return Ok(users);
    }

    [HttpGet("{username}")]
    public async Task<IActionResult> GetUserByUsername(string username)
    {
        try
        {
            IdentityUser user = await _userServices.GetUserByUsername(username);
            return Ok(user);
        }
        catch (InvalidUserException e)
        {
            return NotFound(e.Message);

        }
    }

}