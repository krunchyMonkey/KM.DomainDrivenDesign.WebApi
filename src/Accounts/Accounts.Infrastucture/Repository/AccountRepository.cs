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
    public class AccountRepository : Repository<Account>, IRepository<Account>
    {
        public AccountRepository(CustomDbContext dbContext) : base(dbContext)
        {
        }
    }
}
