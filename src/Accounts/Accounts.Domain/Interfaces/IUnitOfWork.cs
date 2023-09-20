﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Domain.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        void Commit();
        void Rollback();
        IRepository Repository<T>() where T : IEntity;
    }
}
