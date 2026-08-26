using Microsoft.AspNetCore.Mvc;
using Practice.Models;

namespace Practice.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetProduct()
        {
            Product p = new Product
            {
                ID = 1,
                Name = "Áo phông",
                YearRelease = 2026,
                Price = 99.99
            };
            ViewBag.product = p;
            ViewData["product"] = p;
            return View();
        }
        public IActionResult GetAllProducts()
        {
            List<Product> products = new List<Product>()
            {
                new Product() { ID = 1, Name = "Trek 820 - 2016", YearRelease = 2016, Price = 379.99 },
                new Product() { ID = 2, Name = "Ritchey Timberwolf Frameset - 2016", YearRelease = 2016, Price = 749.99 },
                new Product() { ID = 3, Name = "Surly Wednesday Frameset - 2016", YearRelease = 2016, Price = 999.99 },
                new Product() { ID = 4, Name = "Trek Fuel EX 8 29 - 2016", YearRelease = 2016, Price = 2899.99 },
                new Product() { ID = 5, Name = "Heller Shagamaw Frame - 2016", YearRelease = 2016, Price = 1320.99 },
                new Product() { ID = 6, Name = "Surly Ice Cream Truck Frameset - 2016", YearRelease = 2016, Price = 469.99 },
                new Product() { ID = 7, Name = "Trek Slash 8 27.5 - 2016", YearRelease = 2016, Price = 3999.99 },
                new Product() { ID = 8, Name = "Trek Remedy 29 Carbon Frameset - 2016", YearRelease = 2016, Price = 1799.99 },
                new Product() { ID = 9, Name = "Trek Conduit+ - 2016", YearRelease = 2016, Price = 2999.99 },
                new Product() { ID = 10, Name = "Surly Straggler - 2016", YearRelease = 2016, Price = 1549.0 },
                new Product() { ID = 11, Name = "Surly Straggler 650b - 2016", YearRelease = 2016, Price = 1680.99 },
                new Product() { ID = 12, Name = "Electra Townie Original 21D - 2016", YearRelease = 2016, Price = 549.99 },
                new Product() { ID = 13, Name = "Electra Cruiser 1 (24-Inch) - 2016", YearRelease = 2016, Price = 269.99 },
                new Product() { ID = 14, Name = "Electra Girl's Hawaii 1 (16-inch) - 2015/2016", YearRelease = 2016, Price = 269.99 },
            };
            ViewBag.products = products;
            return View("AllProducts");
        }
    }
}
