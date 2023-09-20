using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Domain.Interfaces
{
    public interface IRepository
    {
        T GetById<T>(object id ) where T: IEntity;
        IList<T> GetAll<T>() where T : IEntity;
        void Add<T>(T entity) where T : IEntity;
    }
}
