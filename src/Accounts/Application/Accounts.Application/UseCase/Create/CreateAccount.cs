using Accounts.Application.ViewModel;
using Accounts.Application.ViewModel.Accounts;
using Accounts.Application.ViewModel.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Application.UseCase.Create
{
    public class CreateAccount : IRequest<AccountsResponse<AccountVm>>
    {
        public required CreateAccountRequest CreateAccountRequest { get; set; }
    }
}
