using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBSEntityLayer.NewConcrete;
using System.Linq;

namespace OgrenciBilgiSistemi.Areas.Student.Controllers
{
    [Area("Student")]
    [Route("Student/Profil")]
    public class ProfilController : Controller
    {
        IletisimManager im = new IletisimManager(new EfIletisimDal());
        private readonly UserManager<Kullanicilar> _userManager;
        
     
        
        Context context = new Context();

        public ProfilController(UserManager<Kullanicilar> userManager, Context context)
        {
            _userManager = userManager;
            this.context = context;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
           

            var values = context.Set<Kullanicilar>().Where(x=>x.UserName == User.Identity.Name).Include(x=>x.Kimlik).ThenInclude(x=>x.Iletisim).FirstOrDefault();
            ViewBag.v1 = values.Kimlik.Ad;
            return View(values);
            
        }
        [Route("")]
        [Route("KimlikBilgileri")]
        public IActionResult KimlikBilgileri()
        {
            var values = context.Set<Kullanicilar>().Where(x => x.UserName == User.Identity.Name).Include(x => x.Kimlik).ThenInclude(x => x.Iletisim).FirstOrDefault();

            return View(values);
        }

        [Route("")]
        [Route("IletisimBilgileri")]
        public IActionResult IletisimBilgileri()
        {
            var values = context.Set<Kullanicilar>().Where(x => x.UserName == User.Identity.Name).Include(x => x.Kimlik).ThenInclude(x => x.Iletisim).FirstOrDefault();
            
            return View(values);
        }

        [Route("")]
        [Route("IletisimGuncelle/{id}")]
        [HttpGet]
        public IActionResult IletisimGuncelle(int id)
        {
            var values = context.Set<Kullanicilar>().Where(x => x.UserName == User.Identity.Name).Include(x => x.Kimlik).ThenInclude(x => x.Iletisim).FirstOrDefault();

            return View(values);
        }

        [Route("")]
        [Route("IletisimGuncelle/{id}")]
        [HttpPost]
        public IActionResult IletisimGuncelle(Kullanicilar kullanici)
        {
            Iletisim yeniiletisim = new Iletisim()
            {
                Adres = kullanici.Kimlik.Iletisim.Adres,
                Email = kullanici.Kimlik.Iletisim.Email,
                Il = kullanici.Kimlik.Iletisim.Il,
                Ilce = kullanici.Kimlik.Iletisim.Ilce,
                Gsm = kullanici.Kimlik.Iletisim.Gsm,
                IletisimID = kullanici.Kimlik.IletisimID,







            };
            im.TUpdate(yeniiletisim);
            return RedirectToAction("IletisimBilgileri");
        }
    }
}
