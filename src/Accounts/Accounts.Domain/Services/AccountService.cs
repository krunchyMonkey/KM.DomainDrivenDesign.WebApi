using Accounts.Domain.Interfaces;
using Accounts.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Domain.Services
{
    public class AccountService: IAccountService
    {
        private readonly IAccountDomain _accountDomain;

        public AccountService(IAccountDomain accountDomain) 
        {
            _accountDomain = accountDomain;
        }

        public Account GetAccountById(Guid guid)
        {
            return _accountDomain.GetAccountById(guid);
        }
    }
}
