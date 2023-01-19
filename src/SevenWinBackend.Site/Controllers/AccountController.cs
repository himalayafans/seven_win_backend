using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SevenWinBackend.Domain.Common;
using SevenWinBackend.Site.Library;
using SevenWinBackend.Site.Library.Dto;
using System.IdentityModel.Tokens.Jwt;

namespace SevenWinBackend.Site.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public AjaxResult<string> Login([FromBody] LoginRequest request)
        {
            string token = JwtHelper.GenerateToken(this._configuration, Guid.NewGuid(), "admin");
            return new AjaxResult<string>() { Content = token, Message = "", Success = true };
        }
        [HttpPost]
        public AjaxResult<string> Register([FromBody] RegisterRequest request)
        {
            return new AjaxResult<string>() { Content = "", Message = "", Success = true };
        }

        [HttpPost]
        [Authorize]
        public string Test()
        {
            return "hello";
        }
    }
}
