using Microsoft.AspNetCore.Mvc;
using MyWebsite.Helpers;
using MyWebsite.Models;

namespace MyWebsite.Controllers
{
    public class CartController : Controller
    {
        public const string CartSessionKey = "PHARMACY_CART_SESSION";

        private List<CartItem> GetCartItems()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSessionKey);
            return cart ?? new List<CartItem>();
        }

        private void SaveCartItems(List<CartItem> cart)
        {
            HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);
        }

        // GET: /Cart
        public IActionResult Index()
        {
            var cart = GetCartItems();
            ViewBag.TotalPrice = cart.Sum(item => item.TotalPrice);
            ViewBag.TotalQuantity = cart.Sum(item => item.Quantity);
            return View(cart);
        }

        private bool IsAjaxRequest()
        {
            return Request.Headers["X-Requested-With"] == "XMLHttpRequest" ||
                   Request.Headers.Accept.Any(a => a != null && a.Contains("application/json"));
        }

        // GET: /Cart/GetCartCount
        [HttpGet]
        public IActionResult GetCartCount()
        {
            var cart = GetCartItems();
            return Json(new { count = cart.Sum(i => i.Quantity) });
        }

        // POST: /Cart/AddToCart
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity = 1, string? returnUrl = null)
        {
            if (quantity <= 0) quantity = 1;

            var product = MockRepository.GetProductById(productId);
            if (product == null)
            {
                if (IsAjaxRequest())
                {
                    return Json(new { success = false, message = "Không tìm thấy sản phẩm y tế." });
                }
                return NotFound();
            }

            var cart = GetCartItems();
            var existingItem = cart.FirstOrDefault(c => c.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    ImageUrl = product.ImageUrl,
                    Price = product.Price,
                    Unit = product.Unit,
                    Quantity = quantity
                });
            }

            SaveCartItems(cart);
            int totalQuantity = cart.Sum(item => item.Quantity);
            decimal totalPrice = cart.Sum(item => item.TotalPrice);

            if (IsAjaxRequest())
            {
                return Json(new
                {
                    success = true,
                    message = $"Đã thêm \"{product.Name}\" vào giỏ hàng thành công!",
                    cartCount = totalQuantity,
                    totalPrice = totalPrice.ToString("N0") + " đ",
                    product = new
                    {
                        id = product.Id,
                        name = product.Name,
                        price = product.Price.ToString("N0") + " đ",
                        unit = product.Unit,
                        imageUrl = product.ImageUrl,
                        addedQuantity = quantity
                    }
                });
            }

            TempData["SuccessMessage"] = $"Đã thêm \"{product.Name}\" vào giỏ hàng thành công!";

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index");
        }

        // POST: /Cart/UpdateQuantity
        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int quantity)
        {
            var cart = GetCartItems();
            var item = cart.FirstOrDefault(c => c.ProductId == productId);

            if (item != null)
            {
                if (quantity > 0)
                {
                    item.Quantity = quantity;
                }
                else
                {
                    cart.Remove(item);
                }
                SaveCartItems(cart);
                TempData["SuccessMessage"] = "Đã cập nhật số lượng giỏ hàng.";
            }

            return RedirectToAction("Index");
        }

        // POST: /Cart/Remove
        [HttpPost]
        public IActionResult Remove(int productId)
        {
            var cart = GetCartItems();
            var item = cart.FirstOrDefault(c => c.ProductId == productId);

            if (item != null)
            {
                cart.Remove(item);
                SaveCartItems(cart);
                TempData["SuccessMessage"] = $"Đã xóa \"{item.ProductName}\" khỏi giỏ hàng.";
            }

            return RedirectToAction("Index");
        }

        // POST: /Cart/Clear
        [HttpPost]
        public IActionResult Clear()
        {
            HttpContext.Session.Remove(CartSessionKey);
            TempData["SuccessMessage"] = "Đã làm trống giỏ hàng.";
            return RedirectToAction("Index");
        }

        // GET: /Cart/Checkout
        public IActionResult Checkout()
        {
            var cart = GetCartItems();
            if (!cart.Any())
            {
                TempData["ErrorMessage"] = "Giỏ hàng của bạn đang trống. Vui lòng chọn sản phẩm trước khi thanh toán.";
                return RedirectToAction("Index", "Product");
            }

            ViewBag.Cart = cart;
            ViewBag.TotalPrice = cart.Sum(i => i.TotalPrice);
            return View(new CheckoutViewModel());
        }

        // POST: /Cart/Checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(CheckoutViewModel model)
        {
            var cart = GetCartItems();
            if (!cart.Any())
            {
                TempData["ErrorMessage"] = "Giỏ hàng của bạn đang trống!";
                return RedirectToAction("Index", "Product");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Cart = cart;
                ViewBag.TotalPrice = cart.Sum(i => i.TotalPrice);
                return View(model);
            }

            // Giả lập tạo mã đơn hàng chuẩn y tế
            string orderCode = "AT-PHARMA-" + DateTime.Now.ToString("yyyyMMdd") + "-" + new Random().Next(1000, 9999);
            decimal totalAmount = cart.Sum(i => i.TotalPrice);
            int totalItems = cart.Sum(i => i.Quantity);

            // Xóa session giỏ hàng sau khi đặt thành công
            HttpContext.Session.Remove(CartSessionKey);

            // Lưu dữ liệu vào TempData để trang Success hiển thị
            TempData["OrderCode"] = orderCode;
            TempData["CustomerName"] = model.FullName;
            TempData["CustomerPhone"] = model.PhoneNumber;
            TempData["CustomerAddress"] = $"{model.Address}, {model.City}";
            TempData["PaymentMethod"] = model.PaymentMethod;
            TempData["TotalAmount"] = totalAmount.ToString("N0") + " đ";
            TempData["TotalItems"] = totalItems.ToString();
            TempData["SuccessMessage"] = "Đặt hàng thành công! Đội ngũ Dược sĩ sẽ liên hệ với bạn trong vòng 15 phút để xác nhận đơn.";

            return RedirectToAction("Success");
        }

        // GET: /Cart/Success
        public IActionResult Success()
        {
            if (TempData["OrderCode"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // Keep TempData values for the view
            TempData.Keep();
            return View();
        }
    }
}
