using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreToDo.Services;
using AspNetCoreToDo.Models;

namespace AspNetCoreToDo.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;

        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }
        public async Task<IActionResult> Index()
        {
            //Get to-do items from database
            var items = await _todoItemService.GetIncompleteItemsAsync();
            //put items into a model
            var model = new TodoViewModel()
            {
                Items = items
            };
            // Render view using the model >> users can read and understand
            return View(model);
        }
    }
}