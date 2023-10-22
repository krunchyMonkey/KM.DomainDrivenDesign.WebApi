using Accounts.Application.Mediator.UseCase.Get;
using Accounts.Domain.Business.Interfaces;
using Accounts.Domain.Model;
using Accounts.Application.ViewModel;
using Accounts.Application.ViewModel.Accounts;
using AutoMapper;

namespace Accounts.Application.Mediator.Handlers
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
