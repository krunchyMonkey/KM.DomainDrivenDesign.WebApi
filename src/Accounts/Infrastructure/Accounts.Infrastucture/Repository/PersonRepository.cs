using Accounts.Domain.Business.Interfaces;
using Accounts.Domain.Model;
using Accounts.Infrastucture.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Infrastucture.Repository
{
    public class PersonRepository : Repository<Person>, IRepository<Person>
    {
         public PersonRepository(KrunchypaymentsContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IQueryable<Person>> Query() 
        {
            var result = await base.Query();

            return result;
        }
    }
}
