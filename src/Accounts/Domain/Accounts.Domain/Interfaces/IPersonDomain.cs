﻿using Accounts.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Domain.Interfaces
{
    public interface IPersonDomain
    {
        Task<Person> GetPersonById(Guid id);
    }
}
