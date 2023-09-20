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
        T GetById(object id);
        IList<T> GetAll();
        IQueryable<T> Query();
        void Add(T entity);
        void Rollback();
        void Commit();
        void Dispose();

    }
}
