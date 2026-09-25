using System.ComponentModel.DataAnnotations;

namespace MyWebsite.Models
{
    public class CheckoutViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập họ và tên")]
        [Display(Name = "Họ và tên người nhận")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [RegularExpression(@"^(0[3|5|7|8|9])+([0-9]{8})$", ErrorMessage = "Số điện thoại phải gồm 10 số (bắt đầu bằng 03, 05, 07, 08, 09)")]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        [Display(Name = "Email nhận thông báo (tùy chọn)")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ nhận hàng cụ thể")]
        [Display(Name = "Địa chỉ nhận hàng (Số nhà, tên đường, phường/xã)")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng chọn Tỉnh/Thành phố")]
        [Display(Name = "Tỉnh / Thành phố")]
        public string City { get; set; } = "Hà Nội";

        [Display(Name = "Ghi chú cho Dược sĩ / Shipper")]
        public string? Note { get; set; }

        [Display(Name = "Hình thức thanh toán")]
        public string PaymentMethod { get; set; } = "COD"; // COD, VNPAY, BankTransfer
    }
}
