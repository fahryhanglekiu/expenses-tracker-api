using ExpensesTrackerAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpensesTrackerAPI.Data;

public class CategoryDbContext : DbContext
{
    public CategoryDbContext(DbContextOptions<CategoryDbContext> options) : base(options)
    {
        
    }

    public DbSet<Category> Categories => Set<Category>();
}