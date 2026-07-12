using System.ComponentModel.DataAnnotations;

namespace ExpensesTrackerAPI.DTOs;

public class UserDTO
{
    [Required]
    public string Username{get;set;} = "";

    [Required]
    public string Password {get;set;} = "";
}