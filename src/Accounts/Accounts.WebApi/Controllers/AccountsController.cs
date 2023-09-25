using Accounts.Application.UseCase.Get;
using Accounts.Domain.Interfaces;
using Accounts.Domain.Models;
using Accounts.Infrastucture.ViewModel;
using Accounts.Infrastucture.ViewModel.Accounts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ApiController
    {
        private readonly ILogger<AccountsController> _logger;

        public AccountsController(
            IMediator mediator,
            ILogger<AccountsController> logger) : base(mediator) 
        {
            _logger = logger;
        }
        
   

        [HttpGet(Name = "GetAccountById")]
        public async Task<AccountsResponse<AccountVm>> Get(Guid guid)
        {
            return await Send(new FetchAccountById
            {
                AccountId = guid,
            });
        }

        //[HttpPost(Name = "PostPaymentMethod")]
        //public async Task<Account> Post(Account account) 
        //{
        //    return await _accountService.CreateAccountAsync(account);
        //}

        
    }
}
