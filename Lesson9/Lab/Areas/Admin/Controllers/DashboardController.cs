using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreLA7.Data;
namespace NetCoreLA7.Areas.Admin.Controllers;
[Area("Admin")]
public class DashboardController(AppDbContext db) : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.CategoryCount = await db.Categories.CountAsync();
        ViewBag.ProductCount = await db.Products.CountAsync();
        ViewBag.BannerCount = await db.Banners.CountAsync();
        ViewBag.BlogCount = await db.Blogs.CountAsync();
        return View();
    }
}
