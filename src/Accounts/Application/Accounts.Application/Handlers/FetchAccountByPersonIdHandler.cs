using Accounts.Application.UseCase.Get;
using Accounts.Domain.Interfaces;
using Accounts.Domain.Models;
using Accounts.Application.ViewModel;
using Accounts.Application.ViewModel.Accounts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounts.Application.ViewModel;

namespace Accounts.Application.Handlers
{
    public class FetchAccountByPersonIdHandler : CommandHandler<FetchAccountByPersonId, AccountVm>
    {
        private readonly IAccountProvider _accountProvider;

        public FetchAccountByPersonIdHandler(IAccountProvider accountProvider,
            IMapper mapper) : base(mapper)
        {
            _accountProvider = accountProvider;
        }

        public override async Task<AccountsResponse<AccountVm>> Handle(FetchAccountByPersonId request, CancellationToken cancellationToken)
        {
            var response = await _accountProvider.GetAccountByPersonId(request.PersonId);

            var accountVm = Mapper.Map<Account, AccountVm>(response);

            return CreateAccountsResponse(accountVm);
        }
    }
}
