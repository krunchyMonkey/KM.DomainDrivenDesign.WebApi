using Accounts.Domain.Interfaces;
using Accounts.Domain.Models;
using Accounts.Infrastucture.Context;
using Accounts.Infrastucture.Repository;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Infrastucture
{
    public class AccountsUnitOfWork : IAccountUnitOfWork
    {

        public IRepository<Account> AccountRepository
        {
            get
            {
                return new AccountRepository(_customDbContext);
            }
        }
        public IRepository<Person> PersonRepository
        {
            get
            {
                return new PersonRepository(_customDbContext);
            }
        }
        public IRepository<PaymentMethod> PaymentMethodRepository
        {
            get
            {
                return new PaymentMethodRepository(_customDbContext);
            }
        }

        private readonly CustomDbContext _customDbContext;

        public AccountsUnitOfWork(
            CustomDbContext customDbContext)
        {
            _customDbContext = customDbContext;
        }

        public void Commit()
        {
            _customDbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _customDbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Rollback()
        {
            foreach (var entry in _customDbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }
    }
}