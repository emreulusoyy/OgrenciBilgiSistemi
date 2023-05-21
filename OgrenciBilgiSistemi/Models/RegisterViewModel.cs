using System;
using System.ComponentModel.DataAnnotations;

namespace OgrenciBilgiSistemi.Models
{
    public class RegisterViewModel
    {
        //[Required(ErrorMessage = "Bu alan boş bırakılamaz...")]
        //public string Username { get; set; }

        //[Required(ErrorMessage = "Bu alan boş bırakılamaz...")]
        //public string Password { get; set; }

        //[Required(ErrorMessage = "Bu alan boş bırakılamaz...")]
        //[Compare("Password", ErrorMessage = "Şifreler birbiriyle aynı olmalı...")]
        //public string ContifmPassword { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz...")]
        public string MufredatID { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz...")]
        public string Tc { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz...")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz...")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz...")]
        public string DogumYeri { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz...")]
        public DateTime DogumTarihi { get; set; }

        
    }
}
