namespace ExpensesTrackerAPI.DTOs;

public class AuthResponseDTO
{
    public string Message {get;set;} = string.Empty;

    public AuthResponseDTO(string Message)
    {
        this.Message = Message;
    }
}