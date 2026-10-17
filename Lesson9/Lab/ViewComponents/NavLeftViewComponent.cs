using Microsoft.AspNetCore.Mvc;
namespace NetCoreLA7.ViewComponents;
public class NavLeftViewComponent : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}
