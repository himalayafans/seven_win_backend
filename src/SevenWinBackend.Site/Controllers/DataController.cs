﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SevenWinBackend.Application.Services.Data;
using SevenWinBackend.Domain.Common;
using SevenWinBackend.Domain.Entities;
using SevenWinBackend.Domain.Enums;
using SevenWinBackend.Site.Library.Dto;

namespace SevenWinBackend.Site.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly IMapper _mapper;
        public DataController(AccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }
    }
}
