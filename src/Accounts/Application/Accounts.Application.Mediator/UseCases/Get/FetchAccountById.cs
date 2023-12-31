﻿using Accounts.Application.ViewModel;
using Accounts.Application.ViewModel.Accounts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Application.Mediator.UseCase.Get
{
    public class FetchAccountById : 
        IRequest<AccountsResponse<AccountVm>>
    {
        public Guid AccountId { get; set; }
    }
}
