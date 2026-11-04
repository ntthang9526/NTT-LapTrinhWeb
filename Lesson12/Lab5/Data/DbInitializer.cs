using Microsoft.EntityFrameworkCore;
using Lab5.Models;

namespace Lab5.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolContext(serviceProvider
                .GetRequiredService<DbContextOptions<SchoolContext>>()))
            {
                context.Database.EnsureCreated();
                if (!context.Majors.Any())
                {
                    var majors = new Major[] {
                        new Major{MajorName="IT"},
                        new Major{MajorName="Economics"},
                        new Major{MajorName="Mathematics"},
                    };
                    foreach (var major in majors)
                    {
                        context.Majors.Add(major);
                    }
                    context.SaveChanges();
                }

                if (!context.Learners.Any())
                {
                    var learners = new Learner[] {
                        new Learner { FirstMidName = "Carson", LastName = "Alexander",
                            EnrollmentDate = DateTime.Parse("2005-09-01"), MajorID = 1 },
                        new Learner { FirstMidName = "Meredith", LastName = "Alonso",
                            EnrollmentDate = DateTime.Parse("2002-09-01"), MajorID = 2 }
                    };
                    foreach (Learner l in learners)
                    {
                        context.Learners.Add(l);
                    }
                    context.SaveChanges();
                }

                // Đảm bảo có đủ dữ liệu mẫu cho hiển thị và phân trang/lọc
                if (!context.Learners.Any(l => l.FirstMidName == "Nam"))
                {
                    var additionalLearners = new Learner[] {
                        new Learner { FirstMidName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("2003-09-01"), MajorID = 1 },
                        new Learner { FirstMidName = "Gytis", LastName = "Barzdukas", EnrollmentDate = DateTime.Parse("2002-09-01"), MajorID = 2 },
                        new Learner { FirstMidName = "Nam", LastName = "Lê", EnrollmentDate = DateTime.Parse("2023-10-04 13:59:00"), MajorID = 3 },
                        new Learner { FirstMidName = "Hà", LastName = "Nguyễn", EnrollmentDate = DateTime.Parse("2023-10-04 14:46:00"), MajorID = 2 },
                        new Learner { FirstMidName = "Minh", LastName = "Trần", EnrollmentDate = DateTime.Parse("2023-10-04 14:47:00"), MajorID = 2 },
                        new Learner { FirstMidName = "Bích", LastName = "Vũ", EnrollmentDate = DateTime.Parse("2023-10-23 17:09:00"), MajorID = 2 },
                        new Learner { FirstMidName = "Tuấn Nam", LastName = "Trần", EnrollmentDate = DateTime.Parse("2023-10-05 14:46:00"), MajorID = 1 }
                    };
                    foreach (var l in additionalLearners)
                    {
                        context.Learners.Add(l);
                    }
                    context.SaveChanges();
                }

                if (!context.Courses.Any())
                {
                    var courses = new Course[] {
                        new Course{CourseID=1050, Title="Chemistry", Credits=3},
                        new Course{CourseID=4022, Title="Microeconomics", Credits=3},
                        new Course{CourseID=4041, Title="Macroeconomics", Credits=3}
                    };
                    foreach (Course c in courses)
                    {
                        context.Courses.Add(c);
                    }
                    context.SaveChanges();
                }

                if (!context.Enrollments.Any())
                {
                    var enrollments = new Enrollment[] {
                        new Enrollment{LearnerID=1, CourseID=1050, Grade=5.5f},
                        new Enrollment{LearnerID=1, CourseID=4022, Grade=7.5f},
                        new Enrollment{LearnerID=2, CourseID=1050, Grade=3.5f},
                        new Enrollment{LearnerID=2, CourseID=4041, Grade=7f}
                    };
                    foreach (Enrollment e in enrollments)
                    {
                        context.Enrollments.Add(e);
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
