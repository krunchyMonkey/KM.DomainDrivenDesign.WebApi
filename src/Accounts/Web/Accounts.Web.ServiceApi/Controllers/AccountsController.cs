using Accounts.Application.Mediator.UseCase.Create;
using Accounts.Application.Mediator.UseCase.Get;
using Accounts.Domain.Business.Interfaces;
using Accounts.Domain.Model;
using Accounts.Application.ViewModel;
using Accounts.Application.ViewModel.Accounts;
using Accounts.Application.ViewModel.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.Web.ServiceApi.Controllers
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
        
   

        [HttpGet("Account/{Id}")]
        public async Task<AccountsResponse<AccountVm>> FetchAccountById(Guid Id)
        {
            return await Send(new FetchAccountById
            {
                AccountId = Id,
            });
        }

        [HttpGet("Persons/Person/{Id}")]
        public async Task<AccountsResponse<AccountVm>> FetchAccountByPersonId(Guid Id)
        {
            return await Send(new FetchAccountByPersonId
            {
                PersonId = Id,
            });
        }

        [HttpPost(Name = "CreateAccount")]
        public async Task<AccountsResponse<AccountVm>> CreateAccount(CreateAccountRequest request)
        {
            return await Send(new CreateAccount
            {
                CreateAccountRequest = request
            });
        }
    }
}
