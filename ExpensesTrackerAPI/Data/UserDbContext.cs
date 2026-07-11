using ExpensesTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesTrackerAPI.Data;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users => Set<User>();
}