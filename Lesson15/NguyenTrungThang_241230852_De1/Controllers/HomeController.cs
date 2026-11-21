using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenTrungThang_241230852_De1.Models;

namespace NguyenTrungThang_241230852_De1.Controllers;

public class HomeController : Controller
{
    private readonly QLTaiSanContext _context;

    public HomeController(QLTaiSanContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int? maLoai)
    {
        var loais = await _context.LoaiTaiSans.OrderBy(loai => loai.MaLoai).ToListAsync();
        ViewData["LoaiTaiSans"] = loais;

        if (maLoai.HasValue)
        {
            var loai = loais.Find(item => item.MaLoai == maLoai);
            if (loai is null)
                return NotFound();

            ViewData["MaLoaiDangChon"] = loai.MaLoai;
            ViewData["TieuDeTaiSan"] = loai.TenLoai;
        }

        return View(await LayTaiSan(maLoai));
    }

    [HttpGet]
    public async Task<IActionResult> TaiSanTheoLoai(int maLoai)
    {
        var loai = await _context.LoaiTaiSans.FindAsync(maLoai);
        if (loai is null)
            return NotFound();

        ViewData["TieuDeTaiSan"] = loai.TenLoai;
        return PartialView("_DanhSachTaiSan", await LayTaiSan(maLoai));
    }

    [HttpGet]
    public Task<IActionResult> Create()
    {
        return HienFormThem(new TaiSanInput());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TaiSanInput input)
    {
        if (ModelState.IsValid &&
            !await _context.LoaiTaiSans.AnyAsync(loai => loai.MaLoai == input.MaLoai))
        {
            ModelState.AddModelError(nameof(input.MaLoai), "Loại tài sản không tồn tại.");
        }

        if (!ModelState.IsValid)
            return await HienFormThem(input);

        _context.TaiSans.Add(new TaiSan
        {
            MaLoai = input.MaLoai!.Value,
            TenTs = input.TenTs.Trim(),
            NguyenGia = input.NguyenGia,
            Anh = input.Anh.Trim()
        });

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private async Task<IActionResult> HienFormThem(TaiSanInput input)
    {
        var loais = await _context.LoaiTaiSans.OrderBy(loai => loai.MaLoai).ToListAsync();
        ViewData["LoaiTaiSans"] = loais;
        ViewBag.MaLoaiItems = new SelectList(loais, nameof(LoaiTaiSan.MaLoai), nameof(LoaiTaiSan.TenLoai));
        return View("Create", input);
    }

    private Task<List<TaiSan>> LayTaiSan(int? maLoai)
    {
        var taiSans = maLoai.HasValue
            ? _context.TaiSans.Where(taiSan => taiSan.MaLoai == maLoai)
            : _context.TaiSans.Where(taiSan => taiSan.NguyenGia.HasValue && taiSan.NguyenGia.Value >= 20);

        return taiSans.OrderBy(taiSan => taiSan.MaTs).ToListAsync();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
