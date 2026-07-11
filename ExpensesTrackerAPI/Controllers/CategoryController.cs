using ExpensesTrackerAPI.Data;
using ExpensesTrackerAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpensesTrackerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly CategoryDbContext dbContext;

    public CategoryController(CategoryDbContext context)
    {
        dbContext = context;
    }

    // Get all as list
    [HttpGet]
    public async Task<ActionResult<List<Category>>> GetAll()
    {
        return await dbContext.Categories.ToListAsync();
    }

    // Get by user id
    [HttpGet("user/{userId}")]
    public async Task<ActionResult<List<Category>>> GetByUserId(int userId)
    {
        var categories = await dbContext.Categories.Where(x => x.UserId == userId).ToListAsync();

        return categories;
    }

    // Get by Id
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetById(int id)
    {
        var category = await dbContext.Categories.FindAsync(id);

        if(category == null)
            return NotFound();

        return category;
    }

    // Create
    [HttpPost]
    public async Task<ActionResult<Category>> Create(Category category)
    {
        dbContext.Categories.Add(category);
        await dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new {id = category.Id}, category);
    }

    // Update by id
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Category updatedCategory)
    {
        var category = await dbContext.Categories.FindAsync(id);

        if(category == null)
            return NotFound();

        category.CategoryName = updatedCategory.CategoryName;
        category.CategoryType = updatedCategory.CategoryType;

        await dbContext.SaveChangesAsync();

        return NoContent();
    }

    // Delete
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await dbContext.Categories.FindAsync(id);

        if(category == null)
            return NotFound();
        
        dbContext.Categories.Remove(category);

        await dbContext.SaveChangesAsync();

        return NoContent();
    }
}