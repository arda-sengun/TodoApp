using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private static List<Models.TodoItem> _todos = new List<Models.TodoItem>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_todos);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem todo)
        {
            if (todo == null)
            {
                return BadRequest("Yapılacaklar Listesi Boş.");
            }
            else
            {
                todo.Id = _todos.Count + 1;
                _todos.Add(todo);
                return Ok(todo);
            }

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var todo = _todos.FirstOrDefault(x => x.Id == id);
            if (todo == null)
            {
                return NotFound("Yapılacaklar Listesi Bulunamadı.");
            }
            else
            {
                return Ok(todo);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TodoItem updatedTodo)
        {
            var todo = _todos.FirstOrDefault(x => x.Id == id);
            if (todo == null)
            {
                return NotFound("Yapılacaklar Listesi Bulunamadı.");
            }
            else
            {
                todo.Baslik = updatedTodo.Baslik;
                todo.Icerik = updatedTodo.Icerik;
                todo.OnemDerecesi = updatedTodo.OnemDerecesi;
                todo.Tamamlandi = updatedTodo.Tamamlandi;
                return Ok(todo);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _todos. FirstOrDefault(x => x.Id == id);
            if (todo == null)
            {
                return NotFound("Yapılacaklar Listesi Bulunamadı.");
            }
            else
            {
                _todos.Remove(todo);
                return Ok("Yapılacaklar Listesi Silindi.");
            }
        }
    }
}