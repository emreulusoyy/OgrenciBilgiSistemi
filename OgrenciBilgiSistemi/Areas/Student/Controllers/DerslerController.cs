using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBSEntityLayer.NewConcrete;
using System.Linq;

namespace OgrenciBilgiSistemi.Areas.Student.Controllers
{
    [Area("Student")]
    [Route("Student/Dersler")]
    public class DerslerController : Controller
    {
        Context context = new Context();
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var kullanici = context.Set<Kullanicilar>().Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            var ogrenci = context.Set<Ogrenci>().Where(x => x.KimlikID == kullanici.KimlikID).FirstOrDefault();
            var dersler = context.Set<MufredatDersler>().Where(x => x.MufredatID == ogrenci.MufredatID).Include(x=>x.Dersler).ToList();
  
            return View(dersler);
        }
    }
}
