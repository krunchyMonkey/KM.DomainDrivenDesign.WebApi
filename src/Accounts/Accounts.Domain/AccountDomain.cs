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
    public class AccountDomain : GenericDomain, IAccountDomain
    {
        public AccountDomain(IAccountUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<Account> CreateAccount(Account account)
        {
            var accountId = Guid.NewGuid();

            account.Id = accountId;

            var accountRepo = _accountUnitOfWork.AccountRepository;

            accountRepo.Add(account);

            int recordCount = await _accountUnitOfWork.Commit();

            if (recordCount == 1)
            {
                return await GetAccountById(accountId);
            }
            else 
            {
                throw new Exception($"Record No Created: Number of accounts created: {recordCount}");
            }
        }

        public async Task<Account> GetAccountById(Guid id)
        {
            var accountRepo = _accountUnitOfWork.AccountRepository;

            var results = await accountRepo.Query().Include(t => t.PaymentMethods)
                .Include(t => t.People)
                .Where(t => t.Id == id).SingleAsync();

            return results;
        }

    }
}
