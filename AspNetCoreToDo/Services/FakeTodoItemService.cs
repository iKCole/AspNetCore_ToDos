using System;
using System.Collections;
using System.Threading.Tasks;
using AspNetCoreToDo.Models;

namespace AspNetCoreToDo.Services
{
    public class FakeTodoItemService : ITodoItemService
    {
        public Task<TodoItem[]> GetIncompleteItemsAsync()
        {
            TodoItem item1 = new TodoItem
            {
                Title = "Learn ASP.NET Core",
                Status = "In process",
                DueAt = DateTimeOffset.Now.AddDays(1)
            };

            TodoItem item2 = new TodoItem
            {
                Title = "Build awesome database",
                Status = "Pending",
                DueAt = DateTimeOffset.Now.AddDays(2)
            };

            return Task.FromResult(new[] { item1, item2 });
        }
    }
}