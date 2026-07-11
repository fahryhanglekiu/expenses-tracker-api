using System.ComponentModel.DataAnnotations;

namespace ExpensesTrackerAPI.Models;

public class User
{
    public int Id{get;set;}

    [Required]
    public string Username { get; set; } = "";
    public string? Role { get; set; }
    public string? Password {get; set;}
}