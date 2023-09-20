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
        IEntity GetById(object id);
        IList<IEntity> GetAll();
        void Add(IEntity entity);
    }
}
