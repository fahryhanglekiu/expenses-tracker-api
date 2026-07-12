using ExpensesTrackerAPI.Data;
using ExpensesTrackerAPI.DTOs;
using ExpensesTrackerAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpensesTrackerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserDbContext dbContext;

    public UserController(UserDbContext context)
    {
        dbContext = context;
    }

    // Get all users
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAll()
    {
        return await dbContext.Users.ToListAsync();
    }

    // Get user by id
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetById(int id)
    {
        var user = await dbContext.Users.FindAsync(id);

        if(user == null)
        {
            return NotFound();
        }

        return user;
    }

    // Create User
    [HttpPost]
    public async Task<ActionResult<User>> Create(UserDTO userDTO)
    {
        var user = new User()
        {
            Username = userDTO.Username,
            Password = userDTO.Password,
            CreatedAt = DateTime.UtcNow
        };

        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new {id = user.Id}, user);
    }

    // Update user by id
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UserDTO updatedUserDTO)
    {
        var user = await dbContext.Users.FindAsync(id);

        if(user == null)
            return NotFound();

        user.Username = updatedUserDTO.Username;
        user.Password = updatedUserDTO.Password;

        await dbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await dbContext.Users.FindAsync(id);

        if(user == null)
            return NotFound();

        dbContext.Users.Remove(user);

        await dbContext.SaveChangesAsync();

        return NoContent();
    }
}