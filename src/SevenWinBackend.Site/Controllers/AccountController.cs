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
            var account = await this.accountService.Login(request.Name, request.Password);
            string token = JwtHelper.GenerateToken(this._configuration, account.Id, account.Role.ToString());
            LoginResponse response = new LoginResponse() { Id = account.Id, Name = account.Name, Token = token };
            return new ApiResult<LoginResponse>() { Data = response, Message = "", Success = true };
        }
        [HttpPost]
        public async Task<ApiResult<string>> Register([FromBody] RegisterRequest request)
        {
            await this.accountService.Register(request.Name, request.Password);
            return new ApiResult<string>() { Data = "", Message = "", Success = true };
        }

        [HttpPost]
        [Authorize]
        public string Test()
        {
            return "hello";
        }
    }
}
