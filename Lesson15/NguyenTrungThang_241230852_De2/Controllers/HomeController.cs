using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenTrungThang_241230852_De2.Models;

namespace NguyenTrungThang_241230852_De2.Controllers;

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
    public async Task<IActionResult> Edit(int id)
    {
        var taiSan = await _context.TaiSans.FindAsync(id);
        if (taiSan is null)
            return NotFound();

        return await HienFormSua(id, new TaiSanInput
        {
            MaLoai = taiSan.MaLoai,
            TenTs = taiSan.TenTs,
            NguyenGia = (long?)taiSan.NguyenGia,
            Anh = taiSan.Anh ?? ""
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromRoute] int id, TaiSanInput input)
    {
        var taiSan = await _context.TaiSans.FindAsync(id);
        if (taiSan is null)
            return NotFound();

        if (ModelState.IsValid &&
            !await _context.LoaiTaiSans.AnyAsync(loai => loai.MaLoai == input.MaLoai))
        {
            ModelState.AddModelError(nameof(input.MaLoai), "Loại tài sản không tồn tại.");
        }

        if (!ModelState.IsValid)
            return await HienFormSua(id, input);

        taiSan.MaLoai = input.MaLoai!.Value;
        taiSan.TenTs = input.TenTs.Trim();
        taiSan.NguyenGia = input.NguyenGia;
        taiSan.Anh = input.Anh.Trim();

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Index));
    }

    private async Task<IActionResult> HienFormSua(int id, TaiSanInput input)
    {
        var loais = await _context.LoaiTaiSans.OrderBy(loai => loai.MaLoai).ToListAsync();
        ViewData["LoaiTaiSans"] = loais;
        ViewData["MaTs"] = id;
        ViewBag.MaLoaiItems = new SelectList(loais, nameof(LoaiTaiSan.MaLoai), nameof(LoaiTaiSan.TenLoai));
        return View("Edit", input);
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
