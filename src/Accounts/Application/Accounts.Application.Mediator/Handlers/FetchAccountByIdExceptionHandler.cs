using Accounts.Application.Mediator.UseCase.Get;
using Accounts.Application.ViewModel;
using Accounts.Application.ViewModel.Accounts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Application.Mediator.Handlers
{
    public class FetchAccountByIdExceptionHandler :
        BaseExceptionHandler<FetchAccountById,
        AccountsResponse<AccountVm>,
        Exception,
        AccountVm
        >
    {
        public FetchAccountByIdExceptionHandler(
            ILogger<FetchAccountByIdExceptionHandler> logger) : base(logger)
        {
        }
    }
}
