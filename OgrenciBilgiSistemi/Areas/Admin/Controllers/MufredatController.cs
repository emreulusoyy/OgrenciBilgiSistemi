using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using OBSEntityLayer.NewConcrete;

namespace OgrenciBilgiSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Mufredat")]
    public class MufredatController : Controller
    {
        MufredatManager mm = new MufredatManager(new EfMufredatDal());
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = mm.TGetList();
            return View(values);
        }

        [Route("")]
        [Route("EditMufredat/{id}")]
        [HttpGet]
        public IActionResult EditMufredat(int id)
        {
            var values = mm.TGetByID(id);
            return View(values);
        }

        [Route("")]
        [Route("EditMufredat/{id}")]
        [HttpPost]
        public IActionResult EditMufredat(Mufredat p)
        {
            mm.TUpdate(p);
            return RedirectToAction("Index");
        }

        [Route("")]
        [Route("AddMufredat")]
        [HttpGet]
        public IActionResult AddMufredat()
        {
            return View();
        }

        [Route("")]
        [Route("AddMufredat")]
        [HttpPost]
        public IActionResult AddMufredat(Mufredat p)
        {
            mm.TInsert(p);
            return RedirectToAction("Index");
        }

        [Route("")]
        [Route("DeleteMufredat/{id}")]
        public IActionResult DeleteMufredat(int id)
        {
            var values = mm.TGetByID(id);
            mm.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
