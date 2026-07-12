namespace ExpensesTrackerAPI.Entities;

public class Expense
{
    public int Id {get;set;}
    public int CategoryId {get;set;}
    public string ExpenseName{get;set;} = string.Empty;
    public decimal Amount {get;set;}
    public DateTime Date {get;set;}
    public string? Note {get;set;}
}