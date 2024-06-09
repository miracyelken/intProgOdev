using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Okul.Mvc.Models;

namespace Okul.Mvc.Controllers
{
    public class DersController : Controller
    {
        public IActionResult Index()
        {
            using (var ctx = new OkulDbContext())
            {
                var lst = ctx.Ders.ToList();
                return View(lst);
            }
        }

        public IActionResult AddDers()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDers(Ders ders)
        {
            if (ders != null)
            {
                using (var ctx = new OkulDbContext())
                {
                    ctx.Ders.Add(ders);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult EditDers(int Dersid)
        {
            using (var ctx = new OkulDbContext())
            {
                var ders = ctx.Ders.Find(Dersid);
                return View(ders);
            }
        }

        [HttpPost]
        public IActionResult EditDers(Ders ders)
        {
            if (ders != null)
            {
                using (var ctx = new OkulDbContext())
                {
                    ctx.Entry(ders).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDers(int Dersid)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Ogrenciler.Remove(ctx.Ogrenciler.Find(Dersid));
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
