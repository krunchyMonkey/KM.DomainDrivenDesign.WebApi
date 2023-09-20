using Accounts.Domain.Interfaces;
using Accounts.Infrastucture.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Infrastucture.Repository
{
    public abstract class Repository<T> where T : IEntity
    {
        private readonly CustomDbContext _dbContext;
        private readonly DbSet<IEntity> _dbSet;

        public IEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public Repository(CustomDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<IEntity>();
        }

        public IList<IEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
    }
}
