using BusinessLayer.Abstruct;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OBSEntityLayer.NewConcrete;
using OgrenciBilgiSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OgrenciBilgiSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Ogrenci")]
    public class OgrenciController : Controller
    {
        OgrenciManager om = new OgrenciManager(new EfOgrenciDal());


        MufredatManager mm = new MufredatManager(new EfMufredatDal());

        private readonly UserManager<Kullanicilar> _userManager;

        public OgrenciController(UserManager<Kullanicilar> userManager)
        {
            _userManager = userManager;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            Context context = new Context();

            var values = context.Set<Ogrenci>().Include(x => x.Kimlik).ToList();
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

            var mufredats = mm.TGetList();
            List<SelectListItem> mufredatList = new List<SelectListItem>();
            foreach (var item in mufredats)
            {
                var mufredat = new SelectListItem
                {
                    Text = item.MufredatAdi,
                    Value = item.MufredatID.ToString()
                };
                mufredatList.Add(mufredat);
            }
            ViewBag.Mufredats = mufredatList;



            return View();
        }

        [Route("")]
        [Route("AddOgrenci")]
        [HttpPost]
        public async Task< IActionResult> AddOgrenci(RegisterViewModel p)
        {
            if (ModelState.IsValid)
            {
                string ogrenciNo = "S";
                Random random = new Random();
                for (int i = 0; i < 8; i++)
                {
                    ogrenciNo += random.Next(10);
                }
                Kullanicilar kullanicilar = new Kullanicilar()
                {

                    UserName = ogrenciNo,
                    Kimlik = new OBSEntityLayer.NewConcrete.Kimlik()
                    {
                        Tc = p.Tc,
                        Ad = p.Ad,
                        Soyad = p.Soyad,
                        DogumYeri = p.DogumYeri,
                        DogumTarihi = p.DogumTarihi,

                        Iletisim = new OBSEntityLayer.NewConcrete.Iletisim()
                    }
                };

                string password = p.Ad + p.Tc[0] + p.Tc[1] + p.Tc[2] + "?";

                var result = await _userManager.CreateAsync(kullanicilar, password);

                if (result.Succeeded)
                {
                    var kullanici = await _userManager.FindByNameAsync(ogrenciNo);
                    await _userManager.AddToRoleAsync(kullanici, "Öğrenci");
                    


                    Ogrenci ogrenci = new Ogrenci()
                    {
                        KimlikID = kullanici.KimlikID,
                        MufredatID = Convert.ToInt32(p.MufredatID),
                        OgrenciNo = ogrenciNo
                        
                    };
                    om.TInsert(ogrenci);

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
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
