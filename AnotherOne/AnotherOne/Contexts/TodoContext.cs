using System;
using AnotherOne.Models;
using Microsoft.EntityFrameworkCore;
namespace AnotherOne.Contexts
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

    }
}
