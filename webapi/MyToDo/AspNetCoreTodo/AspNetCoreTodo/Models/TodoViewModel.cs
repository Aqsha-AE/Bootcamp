using System;
using System.ComponentModel.DataAnnotations; 

namespace AspNetCoreTodo.Models;
class TodoViewModel
{
    public TodoItem[]items { get; set; }
}