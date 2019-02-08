using System;
using System.ComponentModel.DataAnnotations;
namespace AnotherOne.Models
{
    public class TodoItem
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public bool IsDone { get; set; }

        public TodoItem() {}
    }
}
