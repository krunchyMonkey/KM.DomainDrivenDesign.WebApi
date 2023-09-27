using Accounts.Domain.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Domain
{
    public abstract class GenericDomain
    {
        protected IAccountUnitOfWork _accountUnitOfWork;

        protected GenericDomain(IAccountUnitOfWork accountUnitOfWork) 
        {
            _accountUnitOfWork = accountUnitOfWork;
        
        }
    }
}
