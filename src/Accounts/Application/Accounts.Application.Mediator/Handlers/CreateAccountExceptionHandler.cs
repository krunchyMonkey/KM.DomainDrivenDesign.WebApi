using Accounts.Application.ViewModel.Accounts;
using Accounts.Application.ViewModel;
using Microsoft.Extensions.Logging;
using Accounts.Application.Mediator.UseCase.Create;

namespace Accounts.Application.Mediator.Handlers
{
    public class CreateAccountExceptionHandler :
        BaseExceptionHandler<CreateAccount,
        AccountsResponse<AccountVm>,
        Exception,
        AccountVm
        >
    {
        public CreateAccountExceptionHandler(
            ILogger<BaseExceptionHandler<CreateAccount, AccountsResponse<AccountVm>, Exception, AccountVm>> logger) : base(logger)
        {
        }
    }
}
