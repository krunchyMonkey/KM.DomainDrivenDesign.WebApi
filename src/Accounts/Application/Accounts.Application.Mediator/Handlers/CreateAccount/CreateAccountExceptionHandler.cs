using Accounts.Application.ViewModel.Accounts;
using Accounts.Application.ViewModel;
using Microsoft.Extensions.Logging;
using Accounts.Application.Mediator.UseCase.Create;

namespace Accounts.Application.Mediator.Handlers.CreateAccount
{
    public class CreateAccountExceptionHandler :
        BaseExceptionHandler<CreateAccountRequest,
        AccountsResponse<AccountVm>,
        Exception,
        AccountVm
        >
    {
        public CreateAccountExceptionHandler(
            ILogger<BaseExceptionHandler<CreateAccountRequest, AccountsResponse<AccountVm>, Exception, AccountVm>> logger) : base(logger)
        {
        }
    }
}
