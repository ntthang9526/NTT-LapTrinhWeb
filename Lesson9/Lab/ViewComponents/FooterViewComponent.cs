using Microsoft.AspNetCore.Mvc;
namespace NetCoreLA7.ViewComponents;
public class FooterViewComponent : ViewComponent
{
    public IViewComponentResult Invoke() => View();
}
