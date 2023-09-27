using Accounts.Domain.Interfaces;
using Accounts.Domain.Models;

namespace Accounts.Domain.Providers
{
    public class AccountProvider: IAccountProvider
    {
        private readonly IAccountDomain _accountDomain;
        private readonly IPersonDomain _personDomain;

        public AccountProvider(
            IAccountDomain accountDomain,
            IPersonDomain personDomain) 
        {
            _accountDomain = accountDomain;
            _personDomain = personDomain;
        }

        public async Task<Account> GetAccountById(Guid guid)
        {
            return await _accountDomain.GetAccountById(guid);
        }

        public async Task<Account> GetAccountByPersonId(Guid personId) 
        {
            var person = await _personDomain.GetPersonById(personId);

            var account = await _accountDomain.GetAccountByPerson(person);

            return account;
        }

        public async Task<Account> CreateAccountAsync(Account account) 
        {
            Person? person;

            if (account == null) 
            {
                throw new ArgumentNullException(nameof(account), "Account cannot be null.");
            }

            if (account.People != null && account.People.Count > 0 && account.People[0]?.Id != null)
            {
                var personId = account.People[0].Id;
                person = await _personDomain.GetPersonById(personId);

                if (person == null) 
                {
                    throw new ArgumentException($"Person with Id: {personId} does not exist");
                }

                var existingAccount = await _accountDomain.GetAccountByPerson(person);

                if (existingAccount != null) 
                {
                    throw new ArgumentException("Person Already Attached to an Account");
                }
            }
            else 
            {
                throw new ArgumentException("Need to Specify a Person to Create Account.");
            }

            account.People = new List<Person> 
            {
                person
            };

            return await _accountDomain.CreateAccount(account);
        }
    }
}
