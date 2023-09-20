using Accounts.Domain.Interfaces;
using Accounts.Domain.Models;
using Accounts.Infrastucture.Context;
using Accounts.Infrastucture.Repository;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Infrastucture
{
    public class AccountsUnitOfWork : IAccountUnitOfWork
    {
        public IRepository<Account> AccountRepository => _accountRespository.Value;
        public IRepository<Person> PersonRepository => _personRespository.Value;
        public IRepository<PaymentMethod> PaymentMethodRepository => _paymentMethodRepository.Value;

        private readonly Lazy<IRepository<Account>> _accountRespository;
        private readonly Lazy<IRepository<Person>> _personRespository;
        private readonly Lazy<IRepository<PaymentMethod>> _paymentMethodRepository;

        public AccountsUnitOfWork(
            Lazy<IRepository<Account>> accoutRepository,
            Lazy<IRepository<Person>> personRepositoy,
            Lazy<IRepository<PaymentMethod>> paymentMethodRepository)
        {
            _accountRespository = accoutRepository;
            _personRespository = personRepositoy;
            _paymentMethodRepository = paymentMethodRepository;

        }


    }
}