using Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab2.Controllers
{
    [Route("Admin/Student")]
    public class StudentController : Controller
    {
        private List<Student> listStudents = new();
        public StudentController()
        {
            listStudents = new List<Student>()
            {
                new Student() {
                    Id = 101,
                    Name = "Hải",
                    Branch = Branch.IT,
                    Gender = Gender.Male,
                    IsRegular = true,
                    Address = "A1-2018",
                    Email = "nam@g.com",
                    DateOfBorth = new DateTime(2003, 5, 15)
                },
                new Student() {
                    Id = 102,
                    Name = "Minh Tú",
                    Branch = Branch.BE,
                    Gender = Gender.Female,
                    IsRegular = true,
                    Address = "A1-2019",
                    Email = "tu@g.com",
                    DateOfBorth = new DateTime(2003, 8, 20)
                },
                new Student() {
                    Id = 103,
                    Name = "Hoàng Phong",
                    Branch = Branch.CE,
                    Gender = Gender.Male,
                    IsRegular = false,
                    Address = "A1-2020",
                    Email = "phong@g.com",
                    DateOfBorth = new DateTime(2002, 11, 10)
                },
                new Student() {
                    Id = 104,
                    Name = "Xuân Mai",
                    Branch = Branch.EE,
                    Gender = Gender.Female,
                    IsRegular = false,
                    Address = "A1-2021",
                    Email = "mai@g.com",
                    DateOfBorth = new DateTime(2003, 3, 25)
                },
                new Student() {
                    Id = 105,
                    Name = "Đức Anh",
                    Branch = Branch.IT,
                    Gender = Gender.Male,
                    IsRegular = true,
                    Address = "A1-2022",
                    Email = "ducanh@g.com",
                    DateOfBorth = new DateTime(2004, 1, 18)
                },
                new Student() {
                    Id = 106,
                    Name = "Thu Hà",
                    Branch = Branch.BE,
                    Gender = Gender.Female,
                    IsRegular = true,
                    Address = "A1-2023",
                    Email = "thuha@g.com",
                    DateOfBorth = new DateTime(2004, 9, 12)
                }
            };
        }
        [Route("List",Name = "student-list")]
        [HttpGet]
        public IActionResult Index()
        {
            return View(listStudents);
        }
        [Route("Add",Name = "student-add")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem{Text = "IT", Value = "1"},
                new SelectListItem{Text = "BE", Value = "2"},
                new SelectListItem{Text = "CE", Value = "3"},
                new SelectListItem{Text = "EE", Value = "4"}
            };
            return View();
        }
        [Route("Add")]
        [HttpPost]
        public IActionResult Create(Student s)
        {
            s.Id = listStudents.Last<Student>().Id + 1;
            listStudents.Add(s);
            return View("Index", listStudents);
        }
    }
}
