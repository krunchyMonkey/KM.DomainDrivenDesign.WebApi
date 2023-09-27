using Accounts.Domain.Business.Interfaces;
using Accounts.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Domain.Business
{
    public class PersonDomain : GenericDomain, IPersonDomain
    {
        public PersonDomain(IAccountUnitOfWork accountUnitOfWork) : base(accountUnitOfWork)
        {
        }

        public async Task<Person?> GetPersonById(Guid id)
        {
            var personRepo = _accountUnitOfWork.PersonRepository;

            var result = await personRepo.Query();

            var person = result.Where(x => x.Id == id)
                               .SingleOrDefault();

            return person;
        }
    }
}
