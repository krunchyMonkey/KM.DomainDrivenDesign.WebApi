using Accounts.Application.UseCase.Get;
using Accounts.Infrastucture.ViewModel.Accounts;
using Accounts.Infrastucture.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Accounts.Application.UseCase.Create
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
