﻿using Accounts.Domain.Interfaces;
using Accounts.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountProvider _accountService;

        public AccountsController(IAccountProvider accountService)
        {
            _accountService = accountService;
        }

        [HttpGet(Name = "GetAccountById")]
        public async Task<Account> Get(Guid guid)
        {
            return await _accountService.GetAccountById(guid);
        }

        [HttpPost(Name = "PostPaymentMethod")]
        public async Task<Account> Post(Account account) 
        {
            return await _accountService.CreateAccountAsync(account);
        }

        
    }
}
