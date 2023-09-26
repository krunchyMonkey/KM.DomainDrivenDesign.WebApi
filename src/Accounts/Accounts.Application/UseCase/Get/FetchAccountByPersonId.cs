using Accounts.Infrastucture.ViewModel.Accounts;
using Accounts.Infrastucture.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Application.UseCase.Get
{
    public class FetchAccountByPersonId : 
        IRequest<AccountsResponse<AccountVm>>
    {
        public Guid PersonId { get; set; }
    }
}
