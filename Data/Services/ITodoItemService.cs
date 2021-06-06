using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Identity;
using AspNetCoreTodo.Data;


namespace AspNetCoreTodo.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync(IdentityUser user);

        Task<bool> AddItemAsync (TodoItem newItem, IdentityUser user);

        Task<bool> MarkDoneAsync(Guid id, IdentityUser user);
    }
}