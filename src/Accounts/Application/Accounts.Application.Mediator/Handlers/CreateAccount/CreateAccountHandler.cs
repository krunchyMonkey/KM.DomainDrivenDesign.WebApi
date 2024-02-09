using Accounts.Domain.Business.Interfaces;
using Accounts.Domain.Model;

using Accounts.Application.ViewModel.Accounts;
using Accounts.Application.ViewModel.Requests;
using AutoMapper;
using Accounts.Application.Mediator.UseCase.Create;
using Accounts.Application.ViewModel;

namespace Accounts.Application.Mediator.Handlers.CreateAccount
{
    public class CreateAccountHandler :
        CommandHandler<CreateAccountRequest,
        AccountVm>
    {
        private readonly IAccountProvider _accountProvider;

        public CreateAccountHandler(
            IAccountProvider accountProvider,
            IMapper mapper) : base(mapper)
        {
            _accountProvider = accountProvider;
        }

        public override async Task<AccountsResponse<AccountVm>> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
        {
            var createAccountRequest = request.CreateAccount;

            var accountRequest = Mapper.Map<ViewModel.Requests.CreateAccount, Account>(request.CreateAccount);

            accountRequest.People = new List<Person>()
            {
                new Person
                {
                    Id = createAccountRequest.PersonId
                }
            };

            var response = await _accountProvider.CreateAccountAsync(accountRequest);

            var accountVm = Mapper.Map<Account, AccountVm>(response);

            return CreateAccountsResponse(accountVm);
        }
    }
}
