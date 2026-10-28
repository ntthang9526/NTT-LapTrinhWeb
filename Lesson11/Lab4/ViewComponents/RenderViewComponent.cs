using Lab4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.ViewComponents;

public class RenderViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var items = new List<MenuItem>
        {
            new() { Id = 1, Name = "Branches", Link = "#branches" },
            new() { Id = 2, Name = "Students", Link = "/Admin/Student/List" },
            new() { Id = 3, Name = "Learners", Link = "/Learner/Index" },
            new() { Id = 4, Name = "Subjects", Link = "#subjects" },
            new() { Id = 5, Name = "Courses", Link = "#courses" }
        };
        return View("RenderLeftMenu", items);
    }
}
