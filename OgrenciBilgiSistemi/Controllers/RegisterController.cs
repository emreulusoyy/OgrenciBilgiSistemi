using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OgrenciBilgiSistemi.Models;
using System.Threading.Tasks;

namespace OgrenciBilgiSistemi.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<Kullanicilar> _userManager;
        private readonly RoleManager<Rol> _rolManager;

        public RegisterController(UserManager<Kullanicilar> userManager, RoleManager<Rol> rolManager)
        {
            _userManager = userManager;
            _rolManager = rolManager;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel p)
        {
            if (ModelState.IsValid)
            {
                Kullanicilar kullanicilar = new Kullanicilar()
                {

                   
                    UserName = p.Username,
                    Kimlik = new OBSEntityLayer.NewConcrete.Kimlik()
                    {
                        Iletisim = new OBSEntityLayer.NewConcrete.Iletisim()
                    }


                };

                var result = await _userManager.CreateAsync(kullanicilar, p.Password);

                if (result.Succeeded)
                {
                    var kullanici = await _userManager.FindByNameAsync(p.Username);
                    if (p.Rol==true)
                    {
                        await _userManager.AddToRoleAsync(kullanici, "Admin");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(kullanici, "Öğrenci");
                    }

                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View();
        }
    }
}
