using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreToDo.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        
        public bool IsDone { get; set; }
        
        [Required]
        public string Title { get; set; }

        public string Status { get; set; }
        
        public DateTimeOffset? DueAt { get; set; } // DateTimeOffset" stores a date/time stamp along with timezone
    }
}