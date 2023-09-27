using Accounts.Domain.Model;
using Accounts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Domain.Business.Interfaces
{
    public interface IAccountUnitOfWork
    {
        IRepository<Account> AccountRepository { get; }
        IRepository<Person> PersonRepository { get; }
        IRepository<PaymentMethod> PaymentMethodRepository { get; }
        
        void Rollback();
        Task<int> Commit();
        Task Dispose();
    }
}
