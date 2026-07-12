using System.ComponentModel.DataAnnotations;

namespace ExpensesTrackerAPI.Entities;

public class User
{
    public int Id{get;set;}
    
    public string Username { get; set; } = "";
    public DateTime CreatedAt {get;set;}
    public string PasswordHash {get; set;} = "";
}