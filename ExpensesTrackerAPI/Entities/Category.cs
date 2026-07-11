using System.ComponentModel.DataAnnotations;

namespace ExpensesTrackerAPI.Entities;

public class Category
{
    public int Id {get;set;}

    [Required]
    public string CategoryName {get;set;} = "";

    public int UserId {get;set;}

    public CategoryType CategoryType {get;set;}
}

public enum CategoryType
{
    Income,
    Expense
}