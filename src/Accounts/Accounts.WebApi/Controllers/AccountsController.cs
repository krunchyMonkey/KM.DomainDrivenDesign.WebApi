using Accounts.Application.UseCase.Create;
using Accounts.Application.UseCase.Get;
using Accounts.Domain.Interfaces;
using Accounts.Domain.Models;
using Accounts.Infrastucture.ViewModel;
using Accounts.Infrastucture.ViewModel.Accounts;
using Accounts.Infrastucture.ViewModel.Requests;
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

        [HttpPost(Name = "CreateAccount")]
        public async Task<AccountsResponse<AccountVm>> Post(CreateAccountRequest request)
        {
            return await Send(new CreateAccount
            {
                CreateAccountRequest = request
            });
        }
    }
}
