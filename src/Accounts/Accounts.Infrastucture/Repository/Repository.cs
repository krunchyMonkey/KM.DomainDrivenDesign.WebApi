using Accounts.Domain.Interfaces;
using Accounts.Infrastucture.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public async Task<TEntity> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Repository(CustomDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<IList<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public IQueryable<TEntity> Query() 
        {
            return _dbSet.AsQueryable();
        }
    }
}
