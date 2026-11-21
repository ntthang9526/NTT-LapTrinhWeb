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
        private readonly QLHangHoaContext _context;

        public HomeController(ILogger<HomeController> logger, QLHangHoaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(int? maLoai)
        {
            var loaiHangs = await _context.LoaiHangs.OrderBy(loai => loai.MaLoai).ToListAsync();
            ViewData["LoaiHangs"] = loaiHangs;

            if (maLoai.HasValue)
            {
                var loai = loaiHangs.Find(item => item.MaLoai == maLoai);
                if (loai is null)
                    return NotFound();

                ViewData["MaLoaiDangChon"] = loai.MaLoai;
                ViewData["TieuDeHangHoa"] = loai.TenLoai;
            }

            return View(await LayHangHoa(maLoai));
        }

        [HttpGet]
        public async Task<IActionResult> HangTheoLoai(int maLoai)
        {
            var loai = await _context.LoaiHangs.FindAsync(maLoai);
            if (loai is null)
                return NotFound();

            ViewData["TieuDeHangHoa"] = loai.TenLoai;
            return PartialView("_DanhSachHangHoa", await LayHangHoa(maLoai));
        }

        [HttpGet]
        public Task<IActionResult> Create()
        {
            return HienFormThemHang(new ThemHangHoaInput());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ThemHangHoaInput input)
        {
            if (ModelState.IsValid &&
                !await _context.LoaiHangs.AnyAsync(loai => loai.MaLoai == input.MaLoai))
            {
                ModelState.AddModelError(nameof(input.MaLoai), "Loại hàng không tồn tại.");
            }

            if (!ModelState.IsValid)
                return await HienFormThemHang(input);

            _context.HangHoas.Add(new HangHoa
            {
                MaLoai = input.MaLoai!.Value,
                TenHang = input.TenHang.Trim(),
                Gia = input.Gia,
                Anh = input.Anh.Trim()
            });

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private Task<List<HangHoa>> LayHangHoa(int? maLoai)
        {
            var hangHoa = maLoai.HasValue
                ? _context.HangHoas.Where(hang => hang.MaLoai == maLoai)
                : _context.HangHoas.Where(hang => hang.Gia.HasValue && hang.Gia.Value >= 100);

            return hangHoa.OrderBy(hang => hang.MaHang).ToListAsync();
        }

        private async Task<IActionResult> HienFormThemHang(ThemHangHoaInput input)
        {
            var loaiHangs = await _context.LoaiHangs.OrderBy(loai => loai.MaLoai).ToListAsync();
            ViewData["LoaiHangs"] = loaiHangs;
            ViewBag.MaLoaiItems = new SelectList(loaiHangs, "MaLoai", "TenLoai");
            return View("Create", input);
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
    }
}
