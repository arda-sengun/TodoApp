namespace TodoApp.Models
{
    public class TodoItemDto
    {
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public onemDerecesi OnemDerecesi { get; set; }
        public bool Tamamlandi { get; set; }
    }
}
