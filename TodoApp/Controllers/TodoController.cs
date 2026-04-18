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
            var todos = await _context.TodoItems.ToListAsync();
            var todoDtos = todos.Select(todo => new TodoItemDto
            {
                Id = todo.Id,
                Baslik = todo.Baslik,
                Icerik = todo.Icerik,
                OnemDerecesi = todo.OnemDerecesi,
                Tamamlandi = todo.Tamamlandi
            });

            return Ok(todoDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            var todoDto = new TodoItemDto
            {
                Id = todo.Id,
                Baslik = todo.Baslik,
                Icerik = todo.Icerik,
                OnemDerecesi = todo.OnemDerecesi,
                Tamamlandi = todo.Tamamlandi
            };

            return Ok(todoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTodoDto todoDto)
        {
            if (todoDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todo = new TodoItem
            {
                Baslik = todoDto.Baslik,
                Icerik = todoDto.Icerik,
                OnemDerecesi = todoDto.OnemDerecesi,
                Tamamlandi = todoDto.Tamamlandi
            };
            _context.TodoItems.Add(todo);
            await _context.SaveChangesAsync();

            var todoItemDto = new TodoItemDto()
            {
                Id = todo.Id,
                Baslik = todo.Baslik,
                Icerik = todo.Icerik,
                OnemDerecesi = todo.OnemDerecesi,
                Tamamlandi = todo.Tamamlandi
            };
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todoItemDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateTodoDto createTodoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Baslik = createTodoDto.Baslik;
            todo.Icerik = createTodoDto.Icerik;
            todo.OnemDerecesi = createTodoDto.OnemDerecesi;
            todo.Tamamlandi = createTodoDto.Tamamlandi;

            await _context.SaveChangesAsync();

            var todoItemDto = new TodoItemDto()
            {
                Id = todo.Id,
                Baslik = todo.Baslik,
                Icerik = todo.Icerik,
                OnemDerecesi = todo.OnemDerecesi,
                Tamamlandi = todo.Tamamlandi
            };

            return Ok(todoItemDto);
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