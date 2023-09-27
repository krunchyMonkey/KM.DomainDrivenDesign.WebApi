using Accounts.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Domain.Business.Interfaces
{
    public interface IAccountProvider
    {
       Task<Account> GetAccountById(Guid guid);
       Task<Account> CreateAccountAsync(Account account);
        Task<Account> GetAccountByPersonId(Guid personId);
    }
}
