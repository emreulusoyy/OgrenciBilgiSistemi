using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using OBSEntityLayer.NewConcrete;

namespace OgrenciBilgiSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Kimlik")]
    public class KimlikController : Controller
    {
        KimlikManager km = new KimlikManager(new EfKimlikDal());


        [Route("")]
        [Route("EditKimlik/{id}")]
        [HttpGet]
        public IActionResult EditKimlik(int id)
        {
            var values = km.TGetByID(id);
            return View(values);
        }

        [Route("")]
        [Route("EditKimlik/{id}")]
        [HttpPost]
        public IActionResult EditKimlik(Kimlik p)
        {
            km.TUpdate(p);
            return RedirectToAction("Index","Ogrenci", new { Area = "Admin" });
        }


    }
}
