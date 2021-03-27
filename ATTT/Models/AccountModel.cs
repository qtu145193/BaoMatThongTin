using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATTT.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
    }
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Yêu cầu nhập tên đăng nhập")]
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(50,MinimumLength =4,ErrorMessage ="Độ dài mật khẩu ít nhất là 4 ký tự")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập lại mật khẩu")]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password",ErrorMessage ="Mật khẩu xác nhận không đúng")]
        public string  ConfirmPassword{ get; set; }

        [Display(Name = "Câu hỏi bảo mật")]
        public string Question1 { get; set; }
        [Required(ErrorMessage ="Phải trả lời câu hỏi")]
        [Display(Name = "Câu trả lời")]
        public string Answer1 { get; set; }
    }
}