using ExpensesTrackerAPI.Data;
using ExpensesTrackerAPI.Models;
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

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAll()
    {
        return await dbContext.Users.ToListAsync();
    }
}