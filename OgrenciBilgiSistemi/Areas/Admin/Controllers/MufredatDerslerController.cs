using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using OBSEntityLayer.NewConcrete;
using System.Linq;

namespace OgrenciBilgiSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/MufredatDersler")]
    public class MufredatDerslerController : Controller
    {


        [Route("")]
        [Route("mufredatDersSil/{id}")]
        [HttpPost]
        public IActionResult mufredatDersSil(MufredatDersler mufredatDersler)
        {

            Context context = new Context();

            mufredatDersler = context.Set<MufredatDersler>().Where(x=>x.MufredatID == mufredatDersler.MufredatID && x.DerslerID == mufredatDersler.DerslerID).FirstOrDefault();
            context.Set<MufredatDersler>().Remove(mufredatDersler);
            context.SaveChanges();

            return RedirectToAction("MufredatDersler","Dersler", new { id = mufredatDersler.MufredatID, Area = "Admin" });
        }
    }
}
