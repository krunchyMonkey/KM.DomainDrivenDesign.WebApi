using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Domain.Interfaces
{
    public interface IRepository<T> where T: IEntity
    {
        Task<T> GetById(object id);
        Task<IList<T>> GetAll();
        IQueryable<T> Query();
        Task Add(T entity);
    }
}
