using ExpensesTrackerAPI.Entities;

namespace ExpensesTrackerAPI.Services.Interfaces;

public interface IJwtService
{
    public string GenerateJwtToken(User user);
}