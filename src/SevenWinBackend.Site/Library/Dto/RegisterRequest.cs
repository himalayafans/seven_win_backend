using System.ComponentModel.DataAnnotations;

namespace SevenWinBackend.Site.Library.Dto
{
    public class RegisterRequest
    {
        [RegularExpression(@"^[0-9a-zA-Z]{3-10}$", ErrorMessage = "用户名长度为3-10，仅包含字母或数字")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "用户名不能为空")]
        public string Name { get; set; } = string.Empty;

        [RegularExpression(@"^\w{5-20}$", ErrorMessage = "密码长度为5-20，仅包含字母、数字、下划线")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "登录密码不能为空")]
        public string Password { get; set; } = string.Empty;
    }
}
