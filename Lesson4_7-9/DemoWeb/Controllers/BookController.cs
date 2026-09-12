using DemoWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoWeb.Controllers
{
    public class BookController : Controller
    {
        protected Book book = new Book();
        public IActionResult Index()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            var books = book.GetBooks();
            return View(books);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
