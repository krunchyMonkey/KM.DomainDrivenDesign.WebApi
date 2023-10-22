using Accounts.Domain.Business.Interfaces;
using Accounts.Domain.Model;
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

        private readonly KrunchypaymentsContext _customDbContext;

        public AccountsUnitOfWork(
            KrunchypaymentsContext customDbContext)
        {
            _customDbContext = customDbContext;
        }

        public Task<int> Commit()
        {
            return _customDbContext.SaveChangesAsync();
        }

        private bool disposed = false;

        protected async virtual Task Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    await _customDbContext.DisposeAsync();
                }
            }
            this.disposed = true;
        }

        public async Task Dispose()
        {
            await Dispose(true);
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