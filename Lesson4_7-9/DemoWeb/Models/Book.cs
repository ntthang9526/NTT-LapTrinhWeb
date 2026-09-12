using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoWeb.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public int GenreID { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int TotalPage { get; set; }
        public string Summary { get; set; }
        public List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book
                {
                    ID = 1,
                    Title = "Đắc nhân tâm",
                    AuthorID = 1,
                    GenreID = 1,
                    Image = "/images/img1.jpg",
                    Price = 200000,
                    TotalPage = 320,
                    Summary = "Nghệ thuật thu phục lòng người và giao tiếp ứng xử để đạt được thành công và xây dựng các mối quan hệ bền vững."
                },
                new Book
                {
                    ID = 2,
                    Title = "Đi tìm lẽ sống",
                    AuthorID = 2,
                    GenreID = 2,
                    Image = "/images/img2.jpg",
                    Price = 220000,
                    TotalPage = 216,
                    Summary = "Hồi ký và liệu pháp tâm lý vượt qua nghịch cảnh trong trại tập trung, giúp con người tìm thấy ý nghĩa và mục đích sống."
                },
                new Book
                {
                    ID = 3,
                    Title = "Hồ Chí Minh một con người và một dân tộc",
                    AuthorID = 3,
                    GenreID = 3,
                    Image = "/images/img3.jpg",
                    Price = 990000,
                    TotalPage = 400,
                    Summary = "Tác phẩm khắc họa sâu sắc cuộc đời, tư tưởng và sự gắn bó mật thiết giữa Chủ tịch Hồ Chí Minh với vận mệnh dân tộc Việt Nam."
                },
                new Book
                {
                    ID = 4,
                    Title = "Nhà giả kim",
                    AuthorID = 4,
                    GenreID = 4,
                    Image = "/images/img4.jpg",
                    Price = 300000,
                    TotalPage = 228,
                    Summary = "Hành trình phiêu lưu tìm kho báu của cậu bé chăn cừu Santiago, gửi gắm thông điệp về việc can đảm theo đuổi ước mơ và lắng nghe trái tim."
                }
            };
        }

        public Book GetBookByID(int ID)
        {
            return this.GetBooks().FirstOrDefault(book => book.ID == ID);
        }

        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value = "1", Text = "Dale Carnegie"},
            new SelectListItem{Value = "2", Text = "Viktor E. Frankl"},
            new SelectListItem{Value = "3", Text = "Trần Dân Tiên"},
            new SelectListItem{Value = "4", Text = "Paulo Coelho"}
        };
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Kỹ năng sống" },
            new SelectListItem { Value = "2", Text = "Tâm lý học" },
            new SelectListItem { Value = "3", Text = "Lịch sử - Tiểu sử" },
            new SelectListItem { Value = "4", Text = "Tiểu thuyết" }
        };
    }
}
