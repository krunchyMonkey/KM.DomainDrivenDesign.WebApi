using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Accounts.Domain.Model;
using Accounts.Domain.Model.Interfaces;

namespace Accounts.Domain.Business.Interfaces
{
    public interface IRepository<T> where T: IEntity
    {
        Task<T> GetById(object id);
        Task<IList<T>> GetAll();
        Task<IQueryable<T>> Query();
        Task Add(T entity);
    }
}
