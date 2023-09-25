using Accounts.Domain.Interfaces;
using Accounts.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Domain.Providers
{
    public class AccountProvider: IAccountProvider
    {
        private readonly IAccountDomain _accountDomain;

        public AccountProvider(IAccountDomain accountDomain) 
        {
            _accountDomain = accountDomain;
        }

        public async Task<Account> GetAccountById(Guid guid)
        {
            return await _accountDomain.GetAccountById(guid);
        }

        public async Task<Account> CreateAccountAsync(Account account) 
        {
            return await _accountDomain.CreateAccount(account);
        }
    }
}
