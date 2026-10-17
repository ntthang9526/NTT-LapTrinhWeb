using Microsoft.AspNetCore.Mvc;
namespace NetCoreLA7.Controllers;
public class HomeController : Controller
{
    public IActionResult Index() => View();
    public IActionResult About() => View();
    public IActionResult Contact() => View();
    public IActionResult Error() => Problem("Có lỗi xảy ra khi xử lý yêu cầu.");
}
