using Demo_Day06.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Day06.Controllers
{
    public class MemberController : Controller
    {
        private static readonly List<Member> members = new List<Member>(){
            new Member{ MemberID = Guid.NewGuid().ToString(), Username = "member1", Fullname = "Thanh vien 1", Password = "12345", Email = "tv1@gmail.com"},
            new Member{ MemberID = Guid.NewGuid().ToString(), Username = "member2", Fullname = "Thanh vien 2", Password = "12345", Email = "tv2@gmail.com"},
            new Member{ MemberID = Guid.NewGuid().ToString(), Username = "member3", Fullname = "Thanh vien 3", Password = "12345", Email = "tv3@gmail.com"},
            new Member{ MemberID = Guid.NewGuid().ToString(), Username = "member4", Fullname = "Thanh vien 4", Password = "12345", Email = "tv4@gmail.com"},
            new Member{ MemberID = Guid.NewGuid().ToString(), Username = "member5", Fullname = "Thanh vien 5", Password = "12345", Email = "tv5@gmail.com"},
            new Member{ MemberID = Guid.NewGuid().ToString(), Username = "member6", Fullname = "Thanh vien 6", Password = "12345", Email = "tv6@gmail.com"}
        };
        public IActionResult Index()
        {
            ViewBag.members = members;
            return View();
        }
        public IActionResult GetMembers()
        {
            return View(members);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
