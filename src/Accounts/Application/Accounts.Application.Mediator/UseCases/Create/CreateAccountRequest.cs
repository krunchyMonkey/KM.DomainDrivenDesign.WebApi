using Accounts.Application.ViewModel;
using Accounts.Application.ViewModel.Accounts;
using Accounts.Application.ViewModel.Requests;
using MediatR;

namespace Accounts.Application.Mediator.UseCase.Create
{
    public class CreateAccountRequest : IRequest<AccountsResponse<AccountVm>>
    {
        public required CreateAccount CreateAccount { get; set; }
    }
}

