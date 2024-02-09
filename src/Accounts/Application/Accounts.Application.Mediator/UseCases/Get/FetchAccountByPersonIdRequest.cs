using Accounts.Application.ViewModel.Accounts;
using Accounts.Application.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Application.Mediator.UseCase.Get
{
    public class FetchAccountByPersonIdRequest : 
        IRequest<AccountsResponse<AccountVm>>
    {
        public Guid PersonId { get; set; }
    }
}
