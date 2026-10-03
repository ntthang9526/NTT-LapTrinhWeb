using Lab.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab.Controllers
{
    public class ProductController : Controller
    {
        public static List<Category> categories = new List<Category>()
        {
            new Category
            {
                ID = 1,
                Name = "Phụ kiện máy tính"
            },
            new Category
            {
                ID = 2,
                Name = "Thiết bị âm thanh"
            },
            new Category
            {
                ID = 3,
                Name = "Màn hình & Hiển thị"
            },
            new Category
            {
                ID = 4,
                Name = "Cáp sạc & Củ sạc"
            }
        };
        public static List<Product> list = new List<Product>()
        {
            new Product
            {
                ID = 1,
                Name = "Thùng Bia Heineken Silver 24 Lon (330ml)",
                Image = "heineken-silver.jpg",
                Price = 430000,
                SalePrice = 380000, // Thấp hơn 10% giá gốc (430,000 * 0.9 = 387,000)
                CategoryID = 1,
                Description = "Thùng bia Heineken Silver lon cao 330ml hương vị êm đầm nhẹ dịu, thích hợp cho các buổi tiệc gia đình và bạn bè."
            },
            new Product
            {
                ID = 2,
                Name = "Thùng Nước Tăng Lực Red Bull Thái (24 Lon)",
                Image = "redbull-thai.jpg",
                Price = 280000,
                SalePrice = 245000, // < 252,000
                CategoryID = 1,
                Description = "Nước tăng lực Red Bull nắp vàng nhập khẩu chính hãng từ Thái Lan, bổ sung năng lượng tức thì và vitamin nhóm B."
            },
            new Product
            {
                ID = 3,
                Name = "Hộp Bánh Quy Bơ Danisa Hoàng Gia Đan Mạch (681g)",
                Image = "banh-danisa-681g.jpg",
                Price = 185000,
                SalePrice = 160000, // < 166,500
                CategoryID = 2,
                Description = "Bánh quy bơ cao cấp Danisa công thức hoàng gia Đan Mạch truyền thống, đóng hộp thiếc sang trọng làm quà tặng."
            },
            new Product
            {
                ID = 4,
                Name = "Dầu Ăn Cao Cấp Simply Đậu Nành Can 5 Lít",
                Image = "dau-an-simply-5l.jpg",
                Price = 275000,
                SalePrice = 240000, // < 247,500
                CategoryID = 3,
                Description = "Dầu đậu nành nguyên chất Simply giàu Omega 3-6-9 và Vitamin E tự nhiên, tốt cho sức khỏe tim mạch."
            },
            new Product
            {
                ID = 5,
                Name = "Gạo ST25 Ông Cua Túi 5kg Chính Hãng Sóc Trăng",
                Image = "gao-st25-5kg.jpg",
                Price = 190000,
                SalePrice = 165000, // < 171,000
                CategoryID = 3,
                Description = "Gạo ngon nhất thế giới ST25 giống chuẩn của kỹ sư Hồ Quang Cua, hạt thon dài, dẻo thơm mùi lá dứa tự nhiên."
            },
            new Product
            {
                ID = 6,
                Name = "Nước Giặt Cửa Trên OMO Matic Túi Tiết Kiệm (3.6kg)",
                Image = "nuoc-giat-omo-36kg.jpg",
                Price = 210000,
                SalePrice = 180000, // < 189,000
                CategoryID = 4,
                Description = "Nước giặt OMO Matic xoáy bay vết bẩn cứng đầu chỉ trong một lần giặt, an toàn cho sợi vải và lưu hương tinh dầu thơm mát."
            }
        };
        // GET: ProductController
        public ActionResult Index()
        {
            return View(list);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.categories = categories;
            ViewBag.count = list.Count;
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.categories = categories;
                    return View(product);
                }
                list.Add(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
