using Accounts.Infrastucture.ViewModel.Accounts;
using Accounts.Infrastucture.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Accounts.Application.UseCase.Get;

namespace Accounts.Application.Handlers
{
    public class FetchAccountByPersonIdExceptionHandler :
        BaseExceptionHandler<FetchAccountByPersonId,
        AccountsResponse<AccountVm>,
        Exception,
        AccountVm
        >
    {
        public FetchAccountByPersonIdExceptionHandler(
            ILogger<BaseExceptionHandler<FetchAccountByPersonId, AccountsResponse<AccountVm>, Exception, AccountVm>> logger) : base(logger)
        {
        }
    }
}
