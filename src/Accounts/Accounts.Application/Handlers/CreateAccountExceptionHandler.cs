using Accounts.Application.UseCase.Get;
using Accounts.Infrastucture.ViewModel.Accounts;
using Accounts.Infrastucture.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
