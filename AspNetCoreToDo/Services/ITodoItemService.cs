using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreToDo.Models;

namespace AspNetCoreToDo.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync();
    }

}