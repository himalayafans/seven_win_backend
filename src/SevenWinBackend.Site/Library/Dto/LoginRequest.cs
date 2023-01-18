using System.ComponentModel.DataAnnotations;

namespace SevenWinBackend.Site.Library.Dto
{
    public class LoginRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "用户名不能为空")]
        public string Name { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "登录密码不能为空")]
        public string Password { get; set; } = string.Empty;
    }
}