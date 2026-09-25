using Microsoft.AspNetCore.Mvc;
using MyWebsite.Models;

namespace MyWebsite.Controllers
{
    public class ProductController : Controller
    {
        // GET: /Product or /Product?categoryId=1&search=panadol&sortOrder=price_asc
        public IActionResult Index(int? categoryId, string? search, string? sortOrder)
        {
            var products = MockRepository.FilterProducts(categoryId, search, sortOrder);
            var categories = MockRepository.GetCategories();

            var viewModel = new ProductFilterViewModel
            {
                Products = products,
                Categories = categories,
                SelectedCategoryId = categoryId,
                SearchTerm = search,
                SortOrder = sortOrder,
                TotalCount = products.Count
            };

            return View(viewModel);
        }

        // GET: /Product/Details/5
        public IActionResult Details(int id)
        {
            var product = MockRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.RelatedProducts = MockRepository.GetRelatedProducts(product.CategoryId, product.Id, 4);
            return View(product);
        }
    }
}
