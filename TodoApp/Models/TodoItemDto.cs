using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class TodoItemDto
    {

        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public onemDerecesi OnemDerecesi { get; set; }
        public bool Tamamlandi { get; set; }
    }
}
