using Lab03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab03.Controllers
{
    [Route("Admin/Student")]
    public class StudentController : Controller
    {
        private static List<Student> listStudents = new();

        public StudentController()
        {
            if (listStudents.Count == 0)
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
                        Email = "nam@gmail.com",
                        DateOfBorth = new DateTime(2003, 5, 15),
                        Score = 8.5
                    },
                    new Student() {
                        Id = 102,
                        Name = "Minh Tú",
                        Branch = Branch.BE,
                        Gender = Gender.Female,
                        IsRegular = true,
                        Address = "A1-2019",
                        Email = "tu@gmail.com",
                        DateOfBorth = new DateTime(2003, 8, 20),
                        Score = 7.0
                    },
                    new Student() {
                        Id = 103,
                        Name = "Hoàng Phong",
                        Branch = Branch.CE,
                        Gender = Gender.Male,
                        IsRegular = false,
                        Address = "A1-2020",
                        Email = "phong@gmail.com",
                        DateOfBorth = new DateTime(2002, 11, 10),
                        Score = 6.5
                    },
                    new Student() {
                        Id = 104,
                        Name = "Xuân Mai",
                        Branch = Branch.EE,
                        Gender = Gender.Female,
                        IsRegular = false,
                        Address = "A1-2021",
                        Email = "mai@gmail.com",
                        DateOfBorth = new DateTime(2003, 3, 25),
                        Score = 9.0
                    },
                    new Student() {
                        Id = 105,
                        Name = "Đức Anh",
                        Branch = Branch.IT,
                        Gender = Gender.Male,
                        IsRegular = true,
                        Address = "A1-2022",
                        Email = "ducanh@gmail.com",
                        DateOfBorth = new DateTime(2004, 1, 18),
                        Score = 8.0
                    },
                    new Student() {
                        Id = 106,
                        Name = "Thu Hà",
                        Branch = Branch.BE,
                        Gender = Gender.Female,
                        IsRegular = true,
                        Address = "A1-2023",
                        Email = "thuha@gmail.com",
                        DateOfBorth = new DateTime(2004, 9, 12),
                        Score = 7.8
                    }
                };
            }
        }

        [Route("List", Name = "student-list")]
        [HttpGet]
        public IActionResult Index()
        {
            return View(listStudents);
        }

        [Route("Add", Name = "student-add")]
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
            if (ModelState.IsValid)
            {
                s.Id = listStudents.Last<Student>().Id + 1;
                listStudents.Add(s);
                return View("Index", listStudents);
            }

            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };
            return View();
        }
    }
}
