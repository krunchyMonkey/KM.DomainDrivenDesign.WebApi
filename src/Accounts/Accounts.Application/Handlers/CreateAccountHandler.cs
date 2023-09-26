using Accounts.Application.UseCase.Create;
using Accounts.Application.UseCase.Get;
using Accounts.Domain.Interfaces;
using Accounts.Domain.Models;
using Accounts.Infrastucture.ViewModel;
using Accounts.Infrastucture.ViewModel.Accounts;
using Accounts.Infrastucture.ViewModel.Requests;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Application.Handlers
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
