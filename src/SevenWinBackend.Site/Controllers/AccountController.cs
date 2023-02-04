using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SevenWinBackend.Application.Services.Data;
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
        private readonly AccountService accountService;
        public AccountController(IConfiguration configuration, AccountService accountService)
        {
            _configuration = configuration;
            this.accountService = accountService;
        }

        [HttpPost]
        public async Task<ApiResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            var account = await this.accountService.Login(request.name, request.password);
            string token = JwtHelper.GenerateToken(this._configuration, account.Id, account.Role.ToString());
            LoginResponse response = new LoginResponse() { id = account.Id, name = account.Name, token = token };
            return new ApiResult<LoginResponse>() { data = response, message = "", success = true };
        }
        [HttpPost]
        public async Task<ApiResult<string>> Register([FromBody] RegisterRequest request)
        {
            await this.accountService.Register(request.Name, request.Password);
            return new ApiResult<string>() { data = "", message = "", success = true };
        }

        [HttpPost]
        [Authorize]
        public string Test()
        {
            return "hello";
        }
    }
}
