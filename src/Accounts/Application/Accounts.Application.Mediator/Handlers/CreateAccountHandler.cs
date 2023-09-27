using Accounts.Domain.Business.Interfaces;
using Accounts.Domain.Model;
using Accounts.Application.ViewModel;
using Accounts.Application.ViewModel.Accounts;
using Accounts.Application.ViewModel.Requests;
using AutoMapper;
using Accounts.Application.Mediator.UseCase.Create;

namespace Accounts.Application.Mediator.Handlers
{
    public class CreateAccountHandler :
        CommandHandler<CreateAccount,
        AccountVm>
    {
        private readonly IAccountProvider _accountProvider;

        public CreateAccountHandler(
            IAccountProvider accountProvider,
            IMapper mapper) : base(mapper)
        {
            _accountProvider = accountProvider;
        }

        public override async Task<AccountsResponse<AccountVm>> Handle(CreateAccount request, CancellationToken cancellationToken)
        {
            var createAccountRequest = request.CreateAccountRequest;

            var accountRequest = Mapper.Map<CreateAccountRequest, Account>(request.CreateAccountRequest);

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
