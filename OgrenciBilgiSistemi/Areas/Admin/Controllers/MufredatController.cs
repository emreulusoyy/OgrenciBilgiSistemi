using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBSEntityLayer.NewConcrete;
using OgrenciBilgiSistemi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
        [Route("OgrenciMufredat/{id}")]
        [HttpGet]
        public IActionResult OgrenciMufredat(int id) //ogrenciID
        {
            Context context = new Context();
            var ogrenci = context.Set<Ogrenci>().Where(x=>x.OgrenciID == id).Include(x=>x.Mufredat).FirstOrDefault();
            var derskayıtList = context.Set<DersKayit>().Where(x=>x.OgrenciID == ogrenci.OgrenciID ).ToList();

            var mufredatDersler = context.Set<MufredatDersler>().Where(x => x.MufredatID == ogrenci.MufredatID).Include(x=>x.Dersler).ToList();
            
            List<DersDurumModel> dersDurums = new List<DersDurumModel>();

            foreach (var item in mufredatDersler)
            {
                var dersDurum = new DersDurumModel()
                {
                    DerslerID = item.DerslerID,
                    Adi = item.Dersler.Adi,
                    Kodu = item.Dersler.Kodu,
                    Durum = false
                };

                if (context.Set<DersKayit>().Where(x=>x.OgrenciID == id && x.DerslerID == item.DerslerID).FirstOrDefault() != null)
                {
                    dersDurum.Durum = true;
                }
                dersDurums.Add(dersDurum);
            }
            ViewBag.Mufredat = ogrenci.Mufredat.MufredatAdi;



            return View(dersDurums);
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
