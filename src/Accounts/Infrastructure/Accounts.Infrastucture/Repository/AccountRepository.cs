using Accounts.Domain.Business.Interfaces;
using Accounts.Domain.Model;
using Accounts.Infrastucture.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Infrastucture.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRespository
    {
        public AccountRepository(KrunchypaymentsContext dbContext) : base(dbContext)
        {
        }

        public override async Task<IQueryable<Account>> Query()
        {
            var result =  await base.Query();

            return result.Include(t => t.PaymentMethods)
                         .Include(t => t.People);
        }

    }
}
