using Accounts.Application.ViewModel.Accounts;
using Accounts.Application.ViewModel;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.Web.ServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        protected readonly IMediator Mediator;

        public ApiController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected async Task<IActionResult> Send<T>(IRequest<AccountsResponse<T>> request)
        {
            var response = await Mediator.Send(request);

            var formatedResponse = new JsonResult(response);

            formatedResponse.StatusCode = response.HttpResultCode;

            return formatedResponse;
        }
    }
}
