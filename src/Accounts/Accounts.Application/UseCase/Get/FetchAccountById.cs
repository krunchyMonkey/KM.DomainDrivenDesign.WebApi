using Accounts.Infrastucture.ViewModel;
using Accounts.Infrastucture.ViewModel.Accounts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Application.UseCase.Get
{
    public class FetchAccountById : 
        IRequest<AccountsResponse<AccountVm>>
    {
        public Guid AccountId { get; set; }
    }
}
