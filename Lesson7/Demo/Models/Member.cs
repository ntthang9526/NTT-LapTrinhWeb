using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    /// <summary>
    /// Model class member
    /// Author: NTThang
    /// </summary>
    public class Member
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Account")]
        [Required(ErrorMessage ="Tài khoản không được để trống")]
        [StringLength(20,MinimumLength = 4,ErrorMessage = "Tài khoản phải có độ dài từ 4-20 kí tự")]
        public string UserName { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage ="Mật khẩu không được để trống")]
        [StringLength(100,MinimumLength = 8,ErrorMessage ="Mật khẩu tối thiểu 8 kí tự")]
        public string Password { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage ="Email không được để trống")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Email không đúng định dạng")]
        public string Email { get; set; }
        [DisplayName("PhoneNumber")]
        [Required(ErrorMessage ="Số điện thoại không được để trống")]
        [RegularExpression(@"^0\d{9,9}", ErrorMessage = "Số điện thoại không đúng định dạng. Ví dụ: 0987654321")]
        public string Phone { get; set; }

    }
}
