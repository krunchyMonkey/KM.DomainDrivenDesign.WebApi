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
    public class PersonDomain : GenericDomain, IPersonDomain
    {
        public PersonDomain(IAccountUnitOfWork accountUnitOfWork) : base(accountUnitOfWork)
        {
        }

        public async Task<Person> GetPersonById(Guid id)
        {
            var personRepo = _accountUnitOfWork.PersonRepository;

            var result = await personRepo.Query()
                                         .Where(x => x.Id == id)
                                         .SingleAsync();

            return result;
        }
    }
}
