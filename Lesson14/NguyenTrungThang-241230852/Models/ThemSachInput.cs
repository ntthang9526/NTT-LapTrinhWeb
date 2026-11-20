using System.ComponentModel.DataAnnotations;

namespace NguyenTrungThang_241230852.Models;

public class ThemSachInput
{
    [Required(ErrorMessage = "Hãy chọn thể loại.")]
    public int? MaTl { get; set; }

    [Required(ErrorMessage = "Hãy nhập tên sách.")]
    [StringLength(100)]
    public string TenSach { get; set; } = "";

    [Required(ErrorMessage = "Hãy nhập giá.")]
    [Range(50, 1000, ErrorMessage = "Giá phải từ 50 đến 1000.")]
    public int? Gia { get; set; }

    [Required(ErrorMessage = "Hãy nhập tên ảnh.")]
    [StringLength(100)]
    [RegularExpression(@"(?i)^[^/\\]+\.(jpg|jpeg|png|webp)$",
        ErrorMessage = "Ảnh phải có đuôi .jpg, .jpeg, .png hoặc .webp.")]
    public string Anh { get; set; } = "";
}