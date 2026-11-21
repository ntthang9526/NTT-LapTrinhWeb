using System.ComponentModel.DataAnnotations;

namespace NguyenTrungThang_241230852_De1.Models;

public class TaiSanInput
{
    [Required(ErrorMessage = "Hãy chọn loại tài sản.")]
    public int? MaLoai { get; set; }

    [Required(ErrorMessage = "Hãy nhập tên tài sản.")]
    [StringLength(100, ErrorMessage = "Tên tài sản tối đa 100 ký tự.")]
    public string TenTs { get; set; } = "";

    [Required(ErrorMessage = "Hãy nhập nguyên giá.")]
    [Range(typeof(long), "1", "2000", ErrorMessage = "Nguyên giá phải từ 1 đến 2000 triệu đồng.")]
    public long? NguyenGia { get; set; }

    [Required(ErrorMessage = "Hãy nhập tên ảnh.")]
    [StringLength(100, ErrorMessage = "Tên ảnh tối đa 100 ký tự.")]
    [RegularExpression(@"^[^/\\]+\.([Jj][Pp][Ee]?[Gg]|[Pp][Nn][Gg]|[Ww][Ee][Bb][Pp])$",
        ErrorMessage = "Ảnh phải có đuôi .jpg, .jpeg, .png hoặc .webp.")]
    public string Anh { get; set; } = "";
}
