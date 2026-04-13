using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class TodoDbContext:DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }
    }
}
