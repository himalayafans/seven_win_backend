using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SevenWinBackend.Application.Services.Data;
using SevenWinBackend.Domain.Common;
using SevenWinBackend.Domain.Entities;
using SevenWinBackend.Domain.Enums;
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
        private readonly IMapper _mapper;
        public AccountController(IConfiguration configuration, AccountService accountService, IMapper mapper)
        {
            _configuration = configuration;
            this.accountService = accountService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ApiResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            var account = await this.accountService.Login(request.name, request.password);
            string? role = Enum.GetName(typeof(RolesType), account.Role);
            if (string.IsNullOrWhiteSpace(role))
            {
                throw new ArgumentException(nameof(role));
            }
            string token = JwtHelper.GenerateToken(this._configuration, account.Id, role);
            LoginResponse response = new LoginResponse() { id = account.Id, name = account.Name, token = token };
            return new ApiResult<LoginResponse>() { data = response, message = "", success = true };
        }
        [HttpPost]
        public async Task<ApiResult<string>> Register([FromBody] RegisterRequest request)
        {
            await this.accountService.Register(request.Name, request.Password);
            return new ApiResult<string>() { data = "", message = "", success = true };
        }

        [HttpGet]
        [Authorize(Roles = nameof(RolesType.Admin))]
        public async Task<ApiResult<List<AccountDTO>>> Search(string? name)
        {
            var list = await accountService.Search(name);
            var newList = _mapper.Map<List<Account>, List<AccountDTO>>(list);
            return new ApiResult<List<AccountDTO>>() { data = newList, success = true };
        }

        [HttpPost]
        [Authorize(Roles = nameof(RolesType.Admin))]
        public async Task<ApiResult<AccountDTO>> Active([FromBody] ActiveAccountRequest request)
        {
            var account = await accountService.Active(request.Id);
            var dto = _mapper.Map<Account, AccountDTO>(account);
            return new ApiResult<AccountDTO>() { data = dto, success = true };
        }


        [HttpPost]
        [Authorize]
        public string Test()
        {
            return "hello";
        }
    }
}
