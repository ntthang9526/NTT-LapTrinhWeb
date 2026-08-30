using Microsoft.AspNetCore.Mvc;
using ProductManagement.Models;
using ProductManagement.Models.Enums;

namespace ProductManagement.Controllers
{
    [Route("danh-sach-san-pham", Name = "products")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<Category> categories = new List<Category>
            {
                new Category(1, "Laptop"),
                new Category(2, "Phụ kiện ngoại vi"),
                new Category(3, "Màn hình"),
                new Category(4, "Thiết bị âm thanh"),
                new Category(5, "Linh kiện máy tính"),
                new Category(6, "Cáp sạc & Phụ kiện")
            };
            List<Product> products = new List<Product>
            {
                new Product(1, "Laptop Gaming Dell G15 5515", Url.Content("~/images/laptop.jpg"), 1000, 900, 1,
                    "AMD Ryzen 7 5800H, RTX 3050Ti 4GB, màn hình 15.6 inch FHD 120Hz mượt mà.", Status.ConHang, new DateOnly(2026, 1, 1)),

                new Product(2, "Chuột không dây Logitech G Pro X Superlight", Url.Content("~/images/mouse.jpg"), 20, 15, 2,
                    "Cảm biến HERO 25K siêu chính xác, trọng lượng siêu nhẹ dưới 63g, kết nối Lightspeed.", Status.ConHang, new DateOnly(2026, 1, 2)),

                new Product(3, "Bàn phím cơ AKKO 3087 v2", Url.Content("~/images/keyboard.jpg"), 50, 45, 2,
                    "Switch Akko CS tự bôi trơn, keycap PBT Double-Shot bền bỉ, layout Tenkeyless gọn gàng.", Status.ConHang, new DateOnly(2026, 1, 3)),

                new Product(4, "Màn hình Dell UltraSharp 24 inch", Url.Content("~/images/monitor.jpg"), 200, 180, 3,
                    "Độ phân giải Full HD, tấm nền IPS chuẩn màu 99% sRGB, chân đế công thái học.", Status.HetHang, new DateOnly(2026, 1, 4)),

                new Product(5, "Tai nghe HyperX Cloud II", Url.Content("~/images/headphone.jpg"), 80, 70, 4,
                    "Âm thanh vòm 7.1 sống động, đệm tai bọc da êm ái, micro khử tiếng ồn có thể tháo rời.", Status.NgungKinhDoanh, new DateOnly(2026, 1, 5)),

                new Product(6, "Loa Bluetooth JBL Flip 6", Url.Content("~/images/loudspeaker.jpg"), 60, 50, 4,
                    "Âm bass mạnh mẽ, chuẩn chống nước bụi IP67, thời lượng pin sử dụng lên đến 12 giờ.", Status.ConHang, new DateOnly(2026, 1, 6)),

                new Product(7, "Webcam Logitech C920 Pro", Url.Content("~/images/webcam.jpg"), 40, 35, 2,
                    "Độ phân giải Full HD 1080p@30fps, tự động lấy nét và tích hợp micro kép khử nhiễu.", Status.ConHang, new DateOnly(2026, 1, 7)),

                new Product(8, "Ổ cứng SSD Samsung 980 Pro 1TB NVMe", Url.Content("~/images/ssd.jpg"), 120, 110, 5,
                    "Chuẩn PCIe 4.0 tốc độ đọc/ghi lên đến 7000MB/s, tản nhiệt hiệu quả và độ bền cao.", Status.HetHang, new DateOnly(2026, 1, 8)),

                new Product(9, "RAM Kingston Fury Beast 16GB DDR4", Url.Content("~/images/ram.jpg"), 75, 65, 5,
                    "Bus 3200MHz, tản nhiệt nhôm đen cao cấp, hỗ trợ Intel XMP 2.0 ép xung tự động.", Status.ConHang, new DateOnly(2026, 1, 9)),

                new Product(10, "Cáp sạc nhanh Type-C to Type-C 100W", Url.Content("~/images/cable.jpg"), 10, 8, 6,
                    "Hỗ trợ chuẩn PD 100W, dây bọc dù chống đứt gãy, chiều dài 1.2m tiện lợi.", Status.NgungKinhDoanh, new DateOnly(2026, 1, 10))
            };
            ViewBag.categories = categories;
            ViewBag.products = products;
            return View();
        }
        [Route("danh-muc", Name ="category")]
        public IActionResult FindByCategory(int id)
        {
            List<Category> categories = new List<Category>
            {
                new Category(1, "Laptop"),
                new Category(2, "Phụ kiện ngoại vi"),
                new Category(3, "Màn hình"),
                new Category(4, "Thiết bị âm thanh"),
                new Category(5, "Linh kiện máy tính"),
                new Category(6, "Cáp sạc & Phụ kiện")
            };
            List<Product> products = new List<Product>
            {
                new Product(1, "Laptop Gaming Dell G15 5515", Url.Content("~/images/laptop.jpg"), 1000, 900, 1,
                    "AMD Ryzen 7 5800H, RTX 3050Ti 4GB, màn hình 15.6 inch FHD 120Hz mượt mà.", Status.ConHang, new DateOnly(2026, 1, 1)),

                new Product(2, "Chuột không dây Logitech G Pro X Superlight", Url.Content("~/images/mouse.jpg"), 20, 15, 2,
                    "Cảm biến HERO 25K siêu chính xác, trọng lượng siêu nhẹ dưới 63g, kết nối Lightspeed.", Status.ConHang, new DateOnly(2026, 1, 2)),

                new Product(3, "Bàn phím cơ AKKO 3087 v2", Url.Content("~/images/keyboard.jpg"), 50, 45, 2,
                    "Switch Akko CS tự bôi trơn, keycap PBT Double-Shot bền bỉ, layout Tenkeyless gọn gàng.", Status.ConHang, new DateOnly(2026, 1, 3)),

                new Product(4, "Màn hình Dell UltraSharp 24 inch", Url.Content("~/images/monitor.jpg"), 200, 180, 3,
                    "Độ phân giải Full HD, tấm nền IPS chuẩn màu 99% sRGB, chân đế công thái học.", Status.HetHang, new DateOnly(2026, 1, 4)),

                new Product(5, "Tai nghe HyperX Cloud II", Url.Content("~/images/headphone.jpg"), 80, 70, 4,
                    "Âm thanh vòm 7.1 sống động, đệm tai bọc da êm ái, micro khử tiếng ồn có thể tháo rời.", Status.NgungKinhDoanh, new DateOnly(2026, 1, 5)),

                new Product(6, "Loa Bluetooth JBL Flip 6", Url.Content("~/images/loudspeaker.jpg"), 60, 50, 4,
                    "Âm bass mạnh mẽ, chuẩn chống nước bụi IP67, thời lượng pin sử dụng lên đến 12 giờ.", Status.ConHang, new DateOnly(2026, 1, 6)),

                new Product(7, "Webcam Logitech C920 Pro", Url.Content("~/images/webcam.jpg"), 40, 35, 2,
                    "Độ phân giải Full HD 1080p@30fps, tự động lấy nét và tích hợp micro kép khử nhiễu.", Status.ConHang, new DateOnly(2026, 1, 7)),

                new Product(8, "Ổ cứng SSD Samsung 980 Pro 1TB NVMe", Url.Content("~/images/ssd.jpg"), 120, 110, 5,
                    "Chuẩn PCIe 4.0 tốc độ đọc/ghi lên đến 7000MB/s, tản nhiệt hiệu quả và độ bền cao.", Status.HetHang, new DateOnly(2026, 1, 8)),

                new Product(9, "RAM Kingston Fury Beast 16GB DDR4", Url.Content("~/images/ram.jpg"), 75, 65, 5,
                    "Bus 3200MHz, tản nhiệt nhôm đen cao cấp, hỗ trợ Intel XMP 2.0 ép xung tự động.", Status.ConHang, new DateOnly(2026, 1, 9)),

                new Product(10, "Cáp sạc nhanh Type-C to Type-C 100W", Url.Content("~/images/cable.jpg"), 10, 8, 6,
                    "Hỗ trợ chuẩn PD 100W, dây bọc dù chống đứt gãy, chiều dài 1.2m tiện lợi.", Status.NgungKinhDoanh, new DateOnly(2026, 1, 10))
            };

            List<Product> findByCategory = products.Where(p => p.CategoryID == id).ToList();

            ViewBag.categories = categories;
            ViewBag.products = findByCategory;
            return View("FindCategory");
        }
        [Route("chi-tiet-san-pham", Name ="product-detail")]
        public IActionResult ShowDetail(int id)
        {
            List<Product> products = new List<Product>
            {
                new Product(1, "Laptop Gaming Dell G15 5515", Url.Content("~/images/laptop.jpg"), 1000, 900, 1,
                    "AMD Ryzen 7 5800H, RTX 3050Ti 4GB, màn hình 15.6 inch FHD 120Hz mượt mà.", Status.ConHang, new DateOnly(2026, 1, 1)),

                new Product(2, "Chuột không dây Logitech G Pro X Superlight", Url.Content("~/images/mouse.jpg"), 20, 15, 2,
                    "Cảm biến HERO 25K siêu chính xác, trọng lượng siêu nhẹ dưới 63g, kết nối Lightspeed.", Status.ConHang, new DateOnly(2026, 1, 2)),

                new Product(3, "Bàn phím cơ AKKO 3087 v2", Url.Content("~/images/keyboard.jpg"), 50, 45, 2,
                    "Switch Akko CS tự bôi trơn, keycap PBT Double-Shot bền bỉ, layout Tenkeyless gọn gàng.", Status.ConHang, new DateOnly(2026, 1, 3)),

                new Product(4, "Màn hình Dell UltraSharp 24 inch", Url.Content("~/images/monitor.jpg"), 200, 180, 3,
                    "Độ phân giải Full HD, tấm nền IPS chuẩn màu 99% sRGB, chân đế công thái học.", Status.HetHang, new DateOnly(2026, 1, 4)),

                new Product(5, "Tai nghe HyperX Cloud II", Url.Content("~/images/headphone.jpg"), 80, 70, 4,
                    "Âm thanh vòm 7.1 sống động, đệm tai bọc da êm ái, micro khử tiếng ồn có thể tháo rời.", Status.NgungKinhDoanh, new DateOnly(2026, 1, 5)),

                new Product(6, "Loa Bluetooth JBL Flip 6", Url.Content("~/images/loudspeaker.jpg"), 60, 50, 4,
                    "Âm bass mạnh mẽ, chuẩn chống nước bụi IP67, thời lượng pin sử dụng lên đến 12 giờ.", Status.ConHang, new DateOnly(2026, 1, 6)),

                new Product(7, "Webcam Logitech C920 Pro", Url.Content("~/images/webcam.jpg"), 40, 35, 2,
                    "Độ phân giải Full HD 1080p@30fps, tự động lấy nét và tích hợp micro kép khử nhiễu.", Status.ConHang, new DateOnly(2026, 1, 7)),

                new Product(8, "Ổ cứng SSD Samsung 980 Pro 1TB NVMe", Url.Content("~/images/ssd.jpg"), 120, 110, 5,
                    "Chuẩn PCIe 4.0 tốc độ đọc/ghi lên đến 7000MB/s, tản nhiệt hiệu quả và độ bền cao.", Status.HetHang, new DateOnly(2026, 1, 8)),

                new Product(9, "RAM Kingston Fury Beast 16GB DDR4", Url.Content("~/images/ram.jpg"), 75, 65, 5,
                    "Bus 3200MHz, tản nhiệt nhôm đen cao cấp, hỗ trợ Intel XMP 2.0 ép xung tự động.", Status.ConHang, new DateOnly(2026, 1, 9)),

                new Product(10, "Cáp sạc nhanh Type-C to Type-C 100W", Url.Content("~/images/cable.jpg"), 10, 8, 6,
                    "Hỗ trợ chuẩn PD 100W, dây bọc dù chống đứt gãy, chiều dài 1.2m tiện lợi.", Status.NgungKinhDoanh, new DateOnly(2026, 1, 10))
            };

            Product product = products.FirstOrDefault(p => p.ID == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.product = product;
            return View();
        }
    }
}
