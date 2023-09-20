using Accounts.Domain.Interfaces;
using Accounts.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Domain
{
    public class AccountDomain : IAccountDomain
    {
        private readonly IRepository<Account> _accountRepsitory;

        public AccountDomain(IAccountUnitOfWork unitOfWork) 
        {
            _accountRepsitory = unitOfWork.AccountRepository; ;
        }
        public Account GetAccount(Guid id)
        {
            var results = _accountRepsitory.Query().Include(t => t.PaymentMethods)
                .Include(t => t.People)
                .Where(t => t.Id == id).SingleOrDefault();

            return results;
        }
    }
}
