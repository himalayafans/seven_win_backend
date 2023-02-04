using System.ComponentModel.DataAnnotations;

namespace SevenWinBackend.Site.Library.Dto
{
    public class LoginRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "用户名不能为空")]
        public string name { get; set; } = string.Empty;
        [Required(AllowEmptyStrings = false, ErrorMessage = "登录密码不能为空")]
        public string password { get; set; } = string.Empty;
    }
}