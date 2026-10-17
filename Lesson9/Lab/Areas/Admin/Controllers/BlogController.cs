using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NetCoreLA7.Data;
using NetCoreLA7.Models;

namespace NetCoreLA7.Areas.Admin.Controllers;

[Area("Admin")]
public class BlogController(AppDbContext db) : Controller
{
    public async Task<IActionResult> Index()
    {
        return View(await db.Blogs.AsNoTracking().OrderByDescending(x => x.Id).ToListAsync());
    }

    public async Task<IActionResult> Details(int id)
    {
        var entity = await db.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null) return NotFound();
        return View(entity);
    }

    public async Task<IActionResult> Create()
    {
        await Task.CompletedTask;
        return View(new Blog());
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Status,Image,Description")] Blog model)
    {
        model.Name = model.Name?.Trim() ?? "";
        await Validate(model);
        if (ModelState.IsValid)
        {
            db.Add(model);
            if (await Save())
            {
                TempData["Success"] = "Thêm mới thành công.";
                return RedirectToAction(nameof(Index));
            }
        }
        
        return View(model);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var model = await db.Blogs.FindAsync(id);
        if (model == null) return NotFound();
        
        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status,Image,Description")] Blog model)
    {
        if (id != model.Id) return BadRequest();
        var entity = await db.Blogs.FindAsync(id);
        if (entity == null) return NotFound();
        model.Name = model.Name?.Trim() ?? "";
        await Validate(model);
        if (ModelState.IsValid)
        {
        entity.Name = model.Name;
        entity.Status = model.Status;
        entity.Image = model.Image;
        entity.Description = model.Description;
            if (await Save())
            {
                TempData["Success"] = "Cập nhật thành công.";
                return RedirectToAction(nameof(Index));
            }
        }
        
        return View(model);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var entity = await db.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null) return NotFound();
        return View(entity);
    }

    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var entity = await db.Blogs.FindAsync(id);
        if (entity == null) return NotFound();
        
        db.Remove(entity);
        try
        {
            await db.SaveChangesAsync();
            TempData["Success"] = "Xóa thành công.";
            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", "Không thể xóa dữ liệu đang được sử dụng. Hãy tải lại trang và thử lại.");
            return View(entity);
        }
    }

    private async Task Validate(Blog model)
    {
        if (string.IsNullOrWhiteSpace(model.Name)) ModelState.AddModelError("Name", "Vui lòng nhập tên.");
        else if (await db.Blogs.AnyAsync(x => x.Name == model.Name && x.Id != model.Id))
            ModelState.AddModelError("Name", "Tên đã tồn tại.");

    }

    private async Task<bool> Save()
    {
        try { await db.SaveChangesAsync(); return true; }
        catch (DbUpdateConcurrencyException) { ModelState.AddModelError("", "Dữ liệu đã thay đổi hoặc bị xóa. Hãy tải lại trang."); }
        catch (DbUpdateException ex) when (ex.InnerException is SqlException sql && (sql.Number == 2601 || sql.Number == 2627))
        { ModelState.AddModelError("Name", "Tên đã tồn tại."); }
        catch (DbUpdateException) { ModelState.AddModelError("", "Không thể lưu dữ liệu. Hãy kiểm tra thông tin và thử lại."); }
        return false;
    }

}
