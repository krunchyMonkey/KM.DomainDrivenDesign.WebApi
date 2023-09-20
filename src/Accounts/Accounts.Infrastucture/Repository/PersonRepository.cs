using Accounts.Domain.Interfaces;
using Accounts.Domain.Models;
using Accounts.Infrastucture.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Infrastucture.Repository
{
    public class PersonRepository : Repository<Person>
    {
        public PersonRepository(CustomDbContext dbContext) : base(dbContext)
        {
        }
    }
}
