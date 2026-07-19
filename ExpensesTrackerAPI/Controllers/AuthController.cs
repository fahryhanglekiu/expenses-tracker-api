using ExpensesTrackerAPI.Data;
using ExpensesTrackerAPI.DTOs;
using ExpensesTrackerAPI.Entities;
using ExpensesTrackerAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpensesTrackerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserDbContext dbContext;
    private readonly IJwtService jwtService;

    public AuthController(UserDbContext dbContext, IJwtService jwtService)
    {
        this.dbContext = dbContext;
        this.jwtService = jwtService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponseDTO>> RegisterUser(UserDTO userDTO)
    {
        var passwordHasher = new PasswordHasher<User>();

        var user = new User()
        {
            Username = userDTO.Username,
            CreatedAt = DateTime.UtcNow
        };

        user.PasswordHash = passwordHasher.HashPassword(user, userDTO.Password);

        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();

        var successResponse = new AuthResponseDTO("Account registration succeed");

        return successResponse;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(UserDTO userDTO)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(user => user.Username == userDTO.Username);

        if(user == null)
            return NotFound("User not found or unregistered");

        var passwordHasher = new PasswordHasher<User>();

        var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, userDTO.Password);

        if(result == PasswordVerificationResult.Failed)
            return Unauthorized("Wrong password!");

        var token = jwtService.GenerateJwtToken(user);

        //return new AuthResponseDTO("Account successfully logged in");
        return Ok(token);
    }

    [HttpPut("change-password")]
    public async Task<ActionResult<AuthResponseDTO>> UpdateUser(UserDTO userDTO)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(user => user.Username == userDTO.Username);

        if(user == null)
            return NotFound();

        var passwordHasher = new PasswordHasher<User>();

        user.PasswordHash = passwordHasher.HashPassword(user, userDTO.Password);

        await dbContext.SaveChangesAsync();

        return new AuthResponseDTO("Successfully update password");
    }
}