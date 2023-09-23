using Accounts.Domain.Interfaces;
using Accounts.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Domain
{
    public class PaymentMethodDomain : GenericDomain, IPaymentMethodDomain
    {
        public PaymentMethodDomain(IAccountUnitOfWork accountUnitOfWork) : base(accountUnitOfWork) { }
 
        public async Task<PaymentMethod> InsertPaymentMethod(PaymentMethod paymentMethod, Account account)
        {
            paymentMethod.Id = Guid.NewGuid();

            var accountRepo = _accountUnitOfWork.AccountRepository;

            account?.PaymentMethods?.Add(paymentMethod);

            return paymentMethod;
        }
    }
}
