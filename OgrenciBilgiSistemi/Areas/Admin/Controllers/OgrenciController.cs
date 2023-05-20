using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using OBSEntityLayer.NewConcrete;

namespace OgrenciBilgiSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Ogrenci")]
    public class OgrenciController : Controller
    {
        OgrenciManager om = new OgrenciManager(new EfOgrenciDal());
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = om.TGetList();
            return View(values);
        }

        [Route("")]
        [Route("EditOgrenci/{id}")]
        [HttpGet]
        public IActionResult EditOgrenci(int id)
        {
            var values = om.TGetByID(id);
            return View(values);
        }

        [Route("")]
        [Route("EditOgrenci/{id}")]
        [HttpPost]
        public IActionResult EditOgrenci(Ogrenci p)
        {
            om.TUpdate(p);
            return RedirectToAction("Index");
        }

        [Route("")]
        [Route("AddOgrenci")]
        [HttpGet]
        public IActionResult AddOgrenci()
        {
            return View();
        }

        [Route("")]
        [Route("AddOgrenci")]
        [HttpPost]
        public IActionResult AddOgrenci(Ogrenci p)
        {
            om.TInsert(p);
            return RedirectToAction("Index");
        }

        [Route("")]
        [Route("DeleteOgrenci/{id}")]
        public IActionResult DeleteOgrenci(int id)
        {
            var values = om.TGetByID(id);
            om.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
