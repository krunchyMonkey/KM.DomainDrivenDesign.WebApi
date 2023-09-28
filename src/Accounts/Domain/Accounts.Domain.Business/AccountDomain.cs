using Accounts.Domain.Business.Interfaces;
using Accounts.Domain.Model;
using Accounts.Domain.Model.Interfaces;

namespace Accounts.Domain.Business
{
    public class AccountDomain : GenericDomain<Account>, IAccountDomain
    {
        public AccountDomain(IAccountUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<Account?> CreateAccount(Account account)
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

        public async Task<Account?> GetAccountByPerson(Person person) 
        {
            var accountRepo = _accountUnitOfWork.AccountRepository;

            var result = await accountRepo.Query();

            var accounts = result.Where(t => t.People
                                 .Contains(person));

            return accounts.SingleOrDefault(); ;
  
        }

        public async Task<Account?> GetAccountById(Guid id)
        {
            var accountRepo = _accountUnitOfWork.AccountRepository;

            var results = await accountRepo.Query();

            var accounts = results.Where(x => x.Id == id);

            return accounts.SingleOrDefault();
        }

        public override async Task<IQueryable<Account>> Query()
        {
            var accountRepo = _accountUnitOfWork.AccountRepository;

            return await accountRepo.Query();
        }
    }
}
