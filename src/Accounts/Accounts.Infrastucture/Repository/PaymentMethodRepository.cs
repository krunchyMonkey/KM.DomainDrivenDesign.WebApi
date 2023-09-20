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
    public class PaymentMethodRepository : Repository<PaymentMethod>, IRepository<PaymentMethod>
    {
        internal PaymentMethodRepository(CustomDbContext dbContext) : base(dbContext)
        {
        }
    }
}
