using Accounts.Application.ViewModel.Accounts;
using Accounts.Application.ViewModel;
using Microsoft.Extensions.Logging;
using Accounts.Application.UseCase.Create;

namespace Accounts.Application.Handlers
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
