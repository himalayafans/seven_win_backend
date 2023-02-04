using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SevenWinBackend.Application.Services.Data;
using SevenWinBackend.Domain.Common;
using SevenWinBackend.Domain.Entities;

namespace SevenWinBackend.Site.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly AccountService _accountService;
        public DataController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<ApiResult<List<Account>>> GetAllAccounts()
        {
            var list = await _accountService.GetAccounts();
            return new ApiResult<List<Account>>() { data = list, success = true };
        }
    }
}
