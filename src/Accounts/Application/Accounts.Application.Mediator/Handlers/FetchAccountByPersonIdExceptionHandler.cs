﻿using Accounts.Application.ViewModel.Accounts;
using Accounts.Application.ViewModel;
using Microsoft.Extensions.Logging;
using Accounts.Application.Mediator.UseCase.Get;

namespace Accounts.Application.Mediator.Handlers
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
