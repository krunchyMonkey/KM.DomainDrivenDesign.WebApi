using Accounts.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Domain.Business.Interfaces
{
    public interface IPaymentMethodRepository: IRepository<PaymentMethod>
    {
    }
}
