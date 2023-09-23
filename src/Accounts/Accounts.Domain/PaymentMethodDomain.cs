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
            if (account == null) 
            {
                throw new ArgumentNullException($"Account Cannot be null");
            }

            paymentMethod.Id = Guid.NewGuid();

            var accountRepo = _accountUnitOfWork.AccountRepository;

            if (account.PaymentMethods == null) 
            {
                account.PaymentMethods = new List<PaymentMethod>();
            } 

            account.PaymentMethods?.Add(paymentMethod);

           await accountRepo.Add(account);

            var numberOfRecords = await _accountUnitOfWork.Commit();

            if (numberOfRecords > 0) 
            {
                var paymentMethodRepo = _accountUnitOfWork.PaymentMethodRepository;
                
                var newPaymentMethod = await paymentMethodRepo.GetById(paymentMethod.Id);

                return newPaymentMethod;
            }

            return paymentMethod;
        }
    }
}
