using Accounts.Application.Mediator.UseCase.Get;
using Accounts.Domain.Business.Interfaces;
using Accounts.Domain.Model;
using Accounts.Application.ViewModel;
using Accounts.Application.ViewModel.Accounts;
using AutoMapper;

namespace Accounts.Application.Mediator.Handlers.FetchAccountById
{
    public class FetchAccountByIdHandler :
        CommandHandler<FetchAccountByIdRequest,
        AccountVm>
    {
        private readonly IAccountProvider _accountProvider;

        public FetchAccountByIdHandler(
            IAccountProvider accountProvider,
            IMapper mapper) : base(mapper)
        {
            _accountProvider = accountProvider;
        }

        public override async Task<AccountsResponse<AccountVm>> Handle(FetchAccountByIdRequest request, CancellationToken cancellationToken)
        {
            var response = await _accountProvider.GetAccountById(request.AccountId);

            var responseVm = Mapper.Map<Account, AccountVm>(response);

            return CreateAccountsResponse(responseVm);
        }
    }
}
