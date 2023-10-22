using Accounts.Domain.Interfaces;
using Accounts.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

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

            await accountRepo.Add(account);

            int recordCount = await _accountUnitOfWork.Commit();

            if (recordCount > 0)
            {
                return await GetAccountById(accountId);
            }
            else 
            {
                throw new Exception($"Record No Created: Number of accounts created: {recordCount}");
            }
        }

        public async Task<Account> GetAccountByPerson(Person person) 
        {
            var accountRepo = _accountUnitOfWork.AccountRepository;

            var result = await accountRepo.Query()
                .Include(t => t.PaymentMethods)
                .Include(t => t.People)
                .Where(t => t.People.Contains(person))
                .SingleOrDefaultAsync();

            return result;
  
        }

        public async Task<Account> GetAccountById(Guid id)
        {
            var accountRepo = _accountUnitOfWork.AccountRepository;

            var results = await accountRepo.Query()
                .Include(t => t.PaymentMethods)
                .Include(t => t.People)
                .Where(t => t.Id == id)
                .SingleAsync();

            return results;
        }

    }
}
