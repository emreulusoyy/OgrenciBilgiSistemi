using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OgrenciBilgiSistemi.Areas.Student.Controllers
{
    [Area("Student")]
    [Route("Student/Müfredat")]
    public class MüfredatController : Controller
    {
        Context context = new Context();
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = context.Set<Kullanicilar>().Where(x => x.UserName == User.Identity.Name).Include(x => x.Kimlik).ThenInclude(x => x.Ogrenci.Mufredat).FirstOrDefault();
            return View(values);
        }
    }

    //ar values = context.Set<Kullanicilar>().Where(x => x.UserName == User.Identity.Name).Include(x => x.Kimlik).ThenInclude(x => x.Kullanicilar.Kimlik.).FirstOrDefault();
}
