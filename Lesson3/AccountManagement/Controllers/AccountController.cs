using AccountManagement.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace AccountManagement.Controllers
{
    [Route("danh-sach-ho-so", Name = "account")]
    public class AccountController : Controller
    {
        List<Account> accounts;
        public IActionResult Index()
        {
            accounts = new List<Account>
            {
                new Account
                {
                    ID = 1,
                    Name = "Nguyen Van A",
                    Email = "nguyenvana@example.com",
                    Phone = "0901234567",
                    Avatar = Url.Content("~/avatars/images.jpg"),
                    Address = "123 Le Loi, Quan 1, TP.HCM",
                    Bio = "Lap trinh vien .NET yeu cong nghe va cafe.",
                    Gender = 1,
                    Birthday = new DateOnly(1995, 5, 15)
                },
                new Account
                {
                    ID = 2,
                    Name = "Tran Thi B",
                    Email = "tranthib@example.com",
                    Phone = "0912345678",
                    Avatar = Url.Content("~/avatars/images1.jpg"),
                    Address = "456 Kim Ma, Ba Dinh, Ha Noi",
                    Bio = "UI/UX Designer thich du lich va chup anh.",
                    Gender = 2,
                    Birthday = new DateOnly(1998, 10, 20)
                },
                new Account
                {
                    ID = 3,
                    Name = "Le Van C",
                    Email = "levanc@example.com",
                    Phone = "0987654321",
                    Avatar = Url.Content("~/avatars/images2.jpg"),
                    Address = "789 Nguyen Van Linh, Hai Chau, Da Nang",
                    Bio = "Product Manager dam me san pham so.",
                    Gender = 0,
                    Birthday = new DateOnly(2000, 1, 8)
                }
            };
            ViewBag.accounts = accounts;
            return View();
        }
        //

        [Route("ho-so", Name ="myprofile")]
        public IActionResult Profile(int id)
        {
            accounts = new List<Account>
            {
                new Account
                {
                    ID = 1,
                    Name = "Nguyen Van A",
                    Email = "nguyenvana@example.com",
                    Phone = "0901234567",
                    Avatar = Url.Content("~/avatars/images.jpg"),
                    Address = "123 Le Loi, Quan 1, TP.HCM",
                    Bio = "Lap trinh vien .NET yeu cong nghe va cafe.",
                    Gender = 1,
                    Birthday = new DateOnly(1995, 5, 15)
                },
                new Account
                {
                    ID = 2,
                    Name = "Tran Thi B",
                    Email = "tranthib@example.com",
                    Phone = "0912345678",
                    Avatar = Url.Content("~/avatars/images1.jpg"),
                    Address = "456 Kim Ma, Ba Dinh, Ha Noi",
                    Bio = "UI/UX Designer thich du lich va chup anh.",
                    Gender = 2,
                    Birthday = new DateOnly(1998, 10, 20)
                },
                new Account
                {
                    ID = 3,
                    Name = "Le Van C",
                    Email = "levanc@example.com",
                    Phone = "0987654321",
                    Avatar = Url.Content("~/avatars/images2.jpg"),
                    Address = "789 Nguyen Van Linh, Hai Chau, Da Nang",
                    Bio = "Product Manager dam me san pham so.",
                    Gender = 0,
                    Birthday = new DateOnly(2000, 1, 8)
                }
            };
            Account account = accounts.FirstOrDefault(acc => acc.ID == id);
            if (account == null) return NotFound();
            ViewBag.account = account;
            return View();

        }
    }
}
