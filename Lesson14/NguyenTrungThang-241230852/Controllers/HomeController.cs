using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenTrungThang_241230852.Models;
using System.Diagnostics;

namespace NguyenTrungThang_241230852.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QLNhaSachContext _context;

        public HomeController(ILogger<HomeController> logger, QLNhaSachContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["TheLoais"] = await _context.TheLoais.OrderBy(loai => loai.MaTl).ToListAsync();
            var sach = await _context.Saches.Where(s => s.Gia.HasValue && s.Gia.Value >= 100).OrderBy(s => s.MaSach).ToListAsync();
            return View(sach);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public async Task<IActionResult> SachTheoTheLoai(int maTl)
        {
            var theLoai = await _context.TheLoais.FirstOrDefaultAsync(loai => loai.MaTl == maTl);
            if (theLoai is null)
            {
                return NotFound();
            }
            var sach = await _context.Saches.Where(s => s.MaTl == maTl).OrderBy(s => s.MaSach).ToListAsync();

            ViewData["TieuDeSach"] = theLoai.TenTl;
            return PartialView("_DanhSachSach", sach);
        }
        [HttpGet]
        public Task<IActionResult> Create()
        {
            return HienFormThemSach(new ThemSachInput());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ThemSachInput input)
        {
            if (ModelState.IsValid &&
                !await _context.TheLoais.AnyAsync(loai => loai.MaTl == input.MaTl))
            {
                ModelState.AddModelError(nameof(input.MaTl), "Thể loại không tồn tại.");
            }

            if (!ModelState.IsValid)
                return await HienFormThemSach(input);

            _context.Saches.Add(new Sach
            {
                MaTl = input.MaTl!.Value,
                TenSach = input.TenSach.Trim(),
                Gia = input.Gia,
                Anh = input.Anh
            });

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<IActionResult> HienFormThemSach(ThemSachInput input)
        {
            var theLoais = await _context.TheLoais.OrderBy(loai => loai.MaTl).ToListAsync();
            ViewData["TheLoais"] = theLoais;
            ViewBag.MaTlItems = new SelectList(theLoais, "MaTl", "TenTl");
            return View("Create", input);
        }
    }
}
