using System;
using System.ComponentModel.DataAnnotations; 

namespace AspNetCoreTodo.Models;

public class Todoitem
{
    //this to defines what the 
    //database will need to store 
    // for each to-do item  
    public Guid Id { get; set; }
    public bool IsDone { get; set; }

    [Required]
    public string Title { get; set; }
    public DateTimeOffset? DueAt { get; set; }
    
}