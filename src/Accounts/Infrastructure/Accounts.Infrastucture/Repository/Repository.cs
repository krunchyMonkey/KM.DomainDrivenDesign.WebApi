﻿using Accounts.Domain.Model.Interfaces;
using Accounts.Infrastucture.Context;
using Microsoft.EntityFrameworkCore;

namespace Accounts.Infrastucture.Repository
{
    public abstract class Repository<TEntity> where TEntity : 
        class, IEntity
    {
        private readonly KrunchypaymentsContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public async Task<TEntity> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Repository(KrunchypaymentsContext dbContext)
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

        public virtual async Task<IQueryable<TEntity>> Query() 
        {
            return await QueryAsync();
        }

        private Task<IQueryable<TEntity>> QueryAsync() 
        {
            return Task.Run(() => _dbSet.AsQueryable());
        }
    }
}
