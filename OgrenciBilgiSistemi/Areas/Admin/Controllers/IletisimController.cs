using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using OBSEntityLayer.NewConcrete;

namespace OgrenciBilgiSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Iletisim")]
    public class IletisimController : Controller
    {
        IletisimManager im = new IletisimManager(new EfIletisimDal());


        [Route("")]
        [Route("EditIletisim/{id}")]
        [HttpGet]
        public IActionResult EditIletisim(int id)
        {
            var values = im.TGetByID(id);
            return View(values);
        }

        [Route("")]
        [Route("EditIletisim/{id}")]
        [HttpPost]
        public IActionResult EditIletisim(Iletisim p)
        {
            im.TUpdate(p);
            return RedirectToAction("Index","Ogrenci", new { Area = "Admin" });
        }

    }
}
