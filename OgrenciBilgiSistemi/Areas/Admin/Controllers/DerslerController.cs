using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using OBSEntityLayer.NewConcrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OgrenciBilgiSistemi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Dersler")]
    public class DerslerController : Controller
    {
        DerslerManager dm = new DerslerManager(new EfDerslerDal());
        MufredatDerslerManager mm = new MufredatDerslerManager(new EfMufredatDerslerDal());

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

        [Route("")]
        [Route("MufredatDersler/{id}")]
        [HttpGet]
        public IActionResult MufredatDersler(int id)
        {
            Context context = new Context();
            var mufredatDersler = context.Set<MufredatDersler>().Where(x => x.MufredatID == id).ToList();
            List<Dersler> dersList = new List<Dersler>();
            foreach (var item in mufredatDersler)
            {
                var ders = context.Set<Dersler>().Where(x => x.DerslerID == item.DerslerID).FirstOrDefault();
                dersList.Add(ders);
            }
            ViewBag.Dersler = dersList;
            ViewBag.MufredatID = id;

            var tumDersler = context.Set<Dersler>().ToList();
            List<Dersler> mufredatDısıDersler = new List<Dersler>();
            foreach (var item in tumDersler)
            {
                if (!dersList.Contains(item))
                {
                    mufredatDısıDersler.Add(item);
                }
            }

            List<SelectListItem> mufredatDısıDerslerList = new List<SelectListItem>();
            foreach (var item in mufredatDısıDersler)
            {
                var derss = new SelectListItem
                {
                    Text = item.Adi,
                    Value = item.DerslerID.ToString()
                };
                mufredatDısıDerslerList.Add(derss);
            }
            ViewBag.mufredatDısıDersler = mufredatDısıDerslerList;

            return View();
        }

        [Route("")]
        [Route("MufredatDersler/{id}")]
        [HttpPost]
        public IActionResult MufredatDersler(MufredatDersler mufredatDersler)
        {

            mm.TInsert(mufredatDersler);

            return RedirectToAction("MufredatDersler", new { id = mufredatDersler.MufredatID });
        }

        //[Route("")]
        //[Route("mufredatDersSil/{id}")]
        //[HttpPost]
        //public IActionResult mufredatDersSil(MufredatDersler mufredatDersler)
        //{

        //    mm.TDelete(mufredatDersler);

        //    return RedirectToAction("MufredatDersler", new { id = mufredatDersler.MufredatID });
        //}

        


    }
}
