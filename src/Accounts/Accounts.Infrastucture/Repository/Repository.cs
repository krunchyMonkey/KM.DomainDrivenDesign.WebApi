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
    public abstract class Repository<TEntity> where TEntity : 
        class, IEntity
    {
        private readonly CustomDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public Repository(CustomDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public IList<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public IQueryable<TEntity> Query() 
        {
            return _dbSet.AsQueryable();
        }
    }
}
