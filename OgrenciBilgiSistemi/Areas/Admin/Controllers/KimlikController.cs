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
        [Route("Index")]
        public IActionResult Index()
        {
            var values = km.TGetList();
            return View(values);
        }

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
            return RedirectToAction("Index");
        }

        [Route("")]
        [Route("AddKimlik")]
        [HttpGet]
        public IActionResult AddKimlik()
        {
            return View();
        }

        [Route("")]
        [Route("AddKimlik")]
        [HttpPost]
        public IActionResult AddKimlik(Kimlik p)
        {
            km.TInsert(p);
            return RedirectToAction("Index");
        }

        [Route("")]
        [Route("DeleteKimlik/{id}")]
        public IActionResult DeleteKimlik(int id)
        {
            var values = km.TGetByID(id);
            km.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
