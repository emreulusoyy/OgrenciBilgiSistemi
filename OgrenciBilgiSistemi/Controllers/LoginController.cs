using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OgrenciBilgiSistemi.Models;
using System.Threading.Tasks;

namespace OgrenciBilgiSistemi.Controllers
{
    [AllowAnonymous]

    public class LoginController : Controller
    {
        private readonly SignInManager<Kullanicilar> _signInManager;
        private readonly UserManager<Kullanicilar> _userManager;

        public LoginController(SignInManager<Kullanicilar> signInManager, UserManager<Kullanicilar> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await _signInManager.SignOutAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, true, true);
                if (result.Succeeded)
                {
                    var kullanici = await _userManager.FindByNameAsync(p.Username);

                    if (await _userManager.IsInRoleAsync(kullanici, "Admin"))
                    {
                        return RedirectToAction("Index", "Iletisim", new { Area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Profil", new { Area = "Student" });
                    }
                 
                }
                else
                {
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("", "Çok fazla hatalı giriş nedeniyle hesap kilitlenmiştir. Daha sonra tekrar deneyin");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Kullanıcı bulunamadı");
                    }

                    return View();
                }
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
