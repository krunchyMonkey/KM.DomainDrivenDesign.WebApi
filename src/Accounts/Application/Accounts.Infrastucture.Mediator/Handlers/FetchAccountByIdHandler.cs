using Accounts.Application.Mediator.UseCase.Get;
using Accounts.Domain.Interfaces;
using Accounts.Domain.Models;
using Accounts.Application.ViewModel;
using Accounts.Application.ViewModel.Accounts;
using AutoMapper;

namespace Accounts.Application.Mediator.Handlers
{
    public class FetchAccountByIdHandler :
        CommandHandler<FetchAccountById,
        AccountVm>
    {
        private readonly IAccountProvider _accountProvider;

        public FetchAccountByIdHandler(
            IAccountProvider accountProvider,
            IMapper mapper) : base(mapper)
        {
            _accountProvider = accountProvider;
        }

        public override async Task<AccountsResponse<AccountVm>> Handle(FetchAccountById request, CancellationToken cancellationToken)
        {
            var response = await _accountProvider.GetAccountById(request.AccountId);

            var responseVm = Mapper.Map<Account, AccountVm>(response);

            return CreateAccountsResponse(responseVm);
        }
    }
}
