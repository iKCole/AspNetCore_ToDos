using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreToDo.Models
{
    public class TodoViewModel
    {
        public TodoItem[] Items { get; set; }
    }
}