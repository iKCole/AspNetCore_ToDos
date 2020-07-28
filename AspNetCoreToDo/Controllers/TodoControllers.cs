using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreToDo.Services;
using AspNetCoreToDo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreToDo.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;
        private readonly UserManager<ApplicationUser> _userManager;

        public TodoController(ITodoItemService todoItemService, UserManager<ApplicationUser> userManager)
        {
            _todoItemService = todoItemService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            if(CurrentUser == null) return Challenge();
            //Get to-do items from database
            var items = await _todoItemService.GetIncompleteItemsAsync(CurrentUser);
            //put items into a model
            var model = new TodoViewModel()
            {
                Items = items
            };
            // Render view using the model >> users can read and understand
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var successful = await _todoItemService.AddItemAsync(newItem); 
            if (!successful)
            {
                return BadRequest(new { error = "Could not add item,"});
            }
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if(id == Guid.Empty)
                return RedirectToAction("Index");

            var successful = await _todoItemService.MarkDoneAsync(id);
            if(!successful)
                return BadRequest("Could not mark item as done.");

            return RedirectToAction("Index");
        }
    }
}