using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using OBSEntityLayer.NewConcrete;

namespace OgrenciBilgiSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Dersler")]
    public class DerslerController : Controller
    {
        DerslerManager dm = new DerslerManager(new EfDerslerDal());

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = dm.TGetList();
            return View(values);
        }

        [Route("")]
        [Route("EditDersler/{id}")]
        [HttpGet]
        public IActionResult EditDersler(int id)
        {
            var values = dm.TGetByID(id);
            return View(values);
        }

        [Route("")]
        [Route("EditDersler/{id}")]
        [HttpPost]
        public IActionResult EditDersler(Dersler p)
        {
            dm.TUpdate(p);
            return RedirectToAction("Index");
        }

        [Route("")]
        [Route("AddDersler")]
        [HttpGet]
        public IActionResult AddDersler( ) 
        {
            return View();
        }

        [Route("")]
        [Route("AddDersler")]
        [HttpPost]
        public IActionResult AddDersler(Dersler p)
        {
            dm.TInsert(p);
            return RedirectToAction("Index");
        }

        [Route("")]
        [Route("DeleteDersler/{id}")]
        public IActionResult DeleteDersler(int id) 
        {
            var values = dm.TGetByID(id);
            dm.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
