using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Okul.Mvc.Models;

namespace Okul.Mvc.Controllers
{
    public class OgrDersSecController : Controller
    {
        private readonly OkulDbContext _context;

        public OgrDersSecController(OkulDbContext context)
        {
            _context = context;
        }

        // GET: /OgrDersSec/Index
        public IActionResult Index()
        {
            var ogrenciler = _context.Ogrenciler.ToList();
            var dersler = _context.Ders.ToList();

            ViewBag.Ogrenciler = ogrenciler;
            ViewBag.Dersler = dersler;

            return View();
        }

        // POST: /OgrDersSec/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int ogrenciId, int dersId)
        {
            if (ModelState.IsValid)
            {
                var ogrenci = await _context.Ogrenciler.FirstOrDefaultAsync(o => o.id == ogrenciId);
                var ders = await _context.Ders.FirstOrDefaultAsync(d => d.Dersid == dersId);

                if (ogrenci != null && ders != null)
                {
                    var yeniKayit = new OgrDers { Ogrenci = ogrenci, Ders = ders };
                    _context.Add(yeniKayit);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index)); // Aynı sayfaya yeniden yönlendirme
                }
            }
            return View();
        }
    }
}
