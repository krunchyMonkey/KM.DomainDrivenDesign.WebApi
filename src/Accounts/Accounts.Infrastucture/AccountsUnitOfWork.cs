using Accounts.Domain.Interfaces;
using Accounts.Domain.Models;
using Accounts.Infrastucture.Context;
using Accounts.Infrastucture.Repository;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Infrastucture
{
    public class AccountsOfWork : IUnitOfWork, IDisposable
    {
        private readonly CustomDbContext _dbContext;
        private bool _disposed;

        public AccountsOfWork(
            CustomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Rollback()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }
        public IRepository Repository<T>() where T : IEntity
        {
            var type = Activator.CreateInstance(typeof(T));

            switch (type)
            {
                case Account:
                    return new AccountRepository(_dbContext);
                case PaymentMethod:
                    return new PaymentMethodRepository(_dbContext);
                case Person:
                    return new PersonRepository(_dbContext);
                    default: throw new Exception("Unsupported Entity Type");
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}