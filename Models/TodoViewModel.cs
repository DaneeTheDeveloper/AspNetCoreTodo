using System;
namespace AspNetCoreTodo.Models
{
  public class TodoViewModel
    {
      public TodoViewModel(){}
      
      public TodoItem[] Items { get; set; }
    }
}