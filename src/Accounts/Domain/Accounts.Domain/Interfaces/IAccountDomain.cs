using Accounts.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Domain.Business.Interfaces
{
    public interface IAccountDomain
    {
        Task<Account> GetAccountById(Guid id);
        Task<Account> CreateAccount(Account account);
        Task<Account> GetAccountByPerson(Person person);
    }
}
