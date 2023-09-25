using Accounts.Domain.Models;
using Accounts.Infrastucture.ViewModel.Accounts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Infrastucture.Mapping.Profiles
{
    public class AccountsProfile : Profile
    {
        public AccountsProfile() 
        {
            Build();
        }

        public void Build() 
        {
            CreateMap<Account, AccountVm>();
            CreateMap<PaymentMethod, PaymentMethodVm>();
            CreateMap<Person, PersonVm>();
        }
    }
}
