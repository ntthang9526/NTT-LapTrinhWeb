using System.ComponentModel.DataAnnotations;

namespace NguyenTrungThang_241230852.Models;

public class ThemHangHoaInput
{
    [Required(ErrorMessage = "Hãy chọn loại hàng.")]
    public int? MaLoai { get; set; }

    [Required(ErrorMessage = "Hãy nhập tên hàng.")]
    [StringLength(50, ErrorMessage = "Tên hàng tối đa 50 ký tự.")]
    public string TenHang { get; set; } = "";

    [Required(ErrorMessage = "Hãy nhập giá.")]
    [Range(100, 5000, ErrorMessage = "Giá phải từ 100 đến 5000.")]
    public int? Gia { get; set; }

    [Required(ErrorMessage = "Hãy nhập tên ảnh.")]
    [StringLength(100, ErrorMessage = "Tên ảnh tối đa 100 ký tự.")]
    [RegularExpression(@"^[^/\\]+\.([Jj][Pp][Gg]|[Pp][Nn][Gg]|[Gg][Ii][Ff]|[Tt][Ii][Ff][Ff])$",
        ErrorMessage = "Ảnh phải có đuôi .jpg, .png, .gif hoặc .tiff.")]
    public string Anh { get; set; } = "";
}
