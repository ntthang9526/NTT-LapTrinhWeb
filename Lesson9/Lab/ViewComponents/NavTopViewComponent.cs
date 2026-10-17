using Microsoft.AspNetCore.Mvc;
namespace NetCoreLA7.ViewComponents;
public class NavTopViewComponent : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}
