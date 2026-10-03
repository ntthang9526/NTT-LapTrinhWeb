using System.ComponentModel.DataAnnotations;

namespace Lab.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }


        [Display(Name="Tên mặt hàng")]
        [Required(ErrorMessage ="Tên mặt hàng không được để trống")]
        [StringLength(150,MinimumLength = 6, ErrorMessage ="Tên mặt hàng phải tối thiểu 6 kí tự và tối đa 150 kí tự")]
        public string Name { get; set; }

        public string? Image { get; set; }


        [Display(Name ="Giá gốc")]
        [Required(ErrorMessage ="Giá gốc không được để trống")]
        [Range(100000,double.MaxValue, ErrorMessage ="Giá gốc không được nhỏ hơn 100000")]
        [DataType(DataType.Text)]
        public double Price { get; set; }


        [Display(Name = "Giá bán")]
        [Required(ErrorMessage = "Giá bán không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá bán không được âm")]
        public double SalePrice { get; set; }


        [Required(ErrorMessage = "Vui lòng chọn danh mục")]
        [Display(Name = "Danh mục")]
        public int CategoryID { get; set; }


        [Required(ErrorMessage = "Mô tả không được để trống")]
        [StringLength(1500, ErrorMessage = "Mô tả không được vượt quá 1500 ký tự")]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

    }
}
