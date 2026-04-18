using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class CreateTodoDto
    {
        [Required(ErrorMessage = "Başlık Zorunludur.")]
        [StringLength(50, ErrorMessage = "Başlık en fazla 50 karakter olabilir.")]
        public string Baslik { get; set; }

        [Required(ErrorMessage = "İçerik Zorunludur.")]
        [StringLength(500, ErrorMessage = "İçerik en fazla 500 karakter olabilir.")]
        public string Icerik { get; set; }
        public onemDerecesi OnemDerecesi { get; set; }
        public bool Tamamlandi { get; set; }
    }
}
