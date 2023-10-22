using Accounts.Domain.Business.Interfaces;
using Accounts.Domain.Model;
using Accounts.Domain.Model.Interfaces;
using Accounts.Infrastucture.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Infrastucture.Repository
{
    public class PaymentMethodRepository : Repository<PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(KrunchypaymentsContext dbContext) : base(dbContext)
        {
        }
    }
}
