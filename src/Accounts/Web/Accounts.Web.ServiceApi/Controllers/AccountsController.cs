using Accounts.Application.Mediator.UseCase.Create;
using Accounts.Application.Mediator.UseCase.Get;
using Accounts.Application.ViewModel.Requests;
using MediatR;
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
        public async Task<IActionResult> FetchAccountById(Guid Id)
        {
            return await Send(new FetchAccountByIdRequest
            {
                AccountId = Id,
            });
        }

        [HttpGet("Persons/Person/{Id}")]
        public async Task<IActionResult> FetchAccountByPersonId(Guid Id)
        {
            return await Send(new FetchAccountByPersonIdRequest
            {
                PersonId = Id,
            });
        }

        [HttpPost(Name = "CreateAccount")]
        public async Task<IActionResult> CreateAccount(CreateAccount request)
        {
            return await Send(new CreateAccountRequest
            {
                CreateAccount = request
            });
        }
    }
}
