using System.ComponentModel.DataAnnotations;

namespace NetCoreLA7.Models;

public class Banner
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên.")]
    [StringLength(100, ErrorMessage = "Tên tối đa 100 ký tự.")]
    [Display(Name = "Tên")]
    public string Name { get; set; } = "";

    [Range(0, 1, ErrorMessage = "Trạng thái phải là 0 hoặc 1.")]
    [Display(Name = "Trạng thái")]
    public byte Status { get; set; } = 1;

    [StringLength(100, ErrorMessage = "Đường dẫn ảnh tối đa 100 ký tự.")]
    [RegularExpression(@"^(?!//)(?:/(?!/)|https?://)[^\s]+$", ErrorMessage = "Nhập đường dẫn /images/ten-anh.jpg hoặc URL http/https.")]
    [Display(Name = "Ảnh")]
    public string? Image { get; set; }

    [StringLength(350, ErrorMessage = "Mô tả tối đa 350 ký tự.")]
    [Display(Name = "Mô tả")]
    public string? Description { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Thứ tự không được âm.")]
    [Display(Name = "Thứ tự")]
    public int Prioty { get; set; }

}
