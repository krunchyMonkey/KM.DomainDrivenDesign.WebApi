using Accounts.Domain.Interfaces;
using Accounts.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService) 
        {
            _accountService = accountService;    
        }

        [HttpGet(Name = "GetAccountById")]
        public Account Get(Guid guid) 
        {
            return _accountService.GetAccountById(guid);
        }

        
    }
}
