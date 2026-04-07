namespace TodoApp.Models
{
    public enum onemDerecesi
    {
        Dusuk,
        Orta,
        Yuksek
    }
    public class TodoItem
    {
        public int Id { get; set; }
        public string Baslik {get; set;}
        public string Icerik { get; set;}
        public onemDerecesi OnemDerecesi { get; set; }
        public bool Tamamlandi { get; set; }
    }
}
