using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OgrenciBilgiSistemi.Models
{
    public class UserLoginViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz...")]
        public string Username { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz...")]
        public string Password { get; set; }
    }
}
