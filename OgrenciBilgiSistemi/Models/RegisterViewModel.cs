using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz...")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz...")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz...")]
        [Compare("Password", ErrorMessage = "Şifreler birbiriyle aynı olmalı...")]
        public string ContifmPassword { get; set; }

        public bool Rol { get; set; } //eğer adminse admin olarak, öğrenci ise öğrenci olarak kaydedilecek
    }
}
