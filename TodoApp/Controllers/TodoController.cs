using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TodoController : ControllerBase
    {
        private readonly TodoDbContext _context;
        public TodoController(TodoDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.TodoItems.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TodoItem todo)
        {
            if (todo == null)
            {
                return BadRequest();
            }
            _context.TodoItems.Add(todo);
            await _context.SaveChangesAsync();
            return Ok(todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TodoItem updatedTodo)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            else
            {
                todo.Baslik = updatedTodo.Baslik;
                todo.Icerik = updatedTodo.Icerik;
                todo.OnemDerecesi = updatedTodo.OnemDerecesi;
                todo.Tamamlandi = updatedTodo.Tamamlandi;

                await _context.SaveChangesAsync();
                return Ok(todo);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            else
            {
                _context.TodoItems.Remove(todo);
                await _context.SaveChangesAsync();
                return Ok(todo);
            }
        }
    }
}