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

        protected async Task<T> Send<T>(IRequest<T> request)
        {
            return await Mediator.Send(request);
        }
    }
}
