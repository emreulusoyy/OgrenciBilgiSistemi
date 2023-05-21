using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OBSEntityLayer.NewConcrete;
using OgrenciBilgiSistemi.Models;
using System;
using System.Collections.Generic;
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
        [HttpGet]
        public IActionResult Index()
        {
            var kullanici = context.Set<Kullanicilar>().Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            var ogrenci = context.Set<Ogrenci>().Where(x => x.KimlikID == kullanici.KimlikID).FirstOrDefault();
            var dersler = context.Set<MufredatDersler>().Where(x => x.MufredatID == ogrenci.MufredatID).Include(x=>x.Dersler).ToList();

            List<DersDurumModel> dersDurums = new List<DersDurumModel>();

            foreach (var item in dersler)
            {
                var dersDurum = new DersDurumModel()
                {
                    DerslerID = item.DerslerID,
                    Adi = item.Dersler.Adi,
                    Kodu = item.Dersler.Kodu,
                    Durum = false
                };

                if (context.Set<DersKayit>().Where(x => x.OgrenciID == ogrenci.OgrenciID && x.DerslerID == item.DerslerID).FirstOrDefault() != null)
                {
                    dersDurum.Durum = true;
                }
                dersDurums.Add(dersDurum);
            }
            ViewBag.OgrenciID = ogrenci.OgrenciID;
            return View(dersDurums);
        }
        [Route("")]
        [Route("Index")]
        [HttpPost]
        public IActionResult Index(DersKayit dersKayit)
        {

            dersKayit.CreatedDate = DateTime.Now;
            context.Set<DersKayit>().Add(dersKayit);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
