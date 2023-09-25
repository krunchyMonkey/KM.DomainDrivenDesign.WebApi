using Accounts.Application.ViewModels;
using Accounts.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Application.UseCase.Get
{
    public class FetchAccountByIdHandler : 
        CommandHandler<FetchAccountById, 
        AccountVm>
    {
        private readonly IAccountProvider _accountProvider;

        public FetchAccountByIdHandler(IAccountProvider accountProvider) 
        {
            _accountProvider = accountProvider;
        }

        public override async Task<AccountsResponse<AccountVm>> Handle(FetchAccountById request, CancellationToken cancellationToken)
        {
            var response = await _accountProvider.GetAccountById(request.AccountId);

            return null;
        }
    }
}
