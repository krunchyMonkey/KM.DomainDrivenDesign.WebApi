using Accounts.Domain.Models;
using Accounts.Infrastucture.ViewModel.Accounts;
using Accounts.Infrastucture.ViewModel.Requests;
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

        public void CommandReqests() 
        {
            CreateMap<CreateAccountRequest, Person>()
                    .ForMember(destination => destination.Id, source => source.MapFrom(s => s.PersonId))
                    .ForMember(destination => destination.FirstName, opt => opt.Ignore())
                    .ForMember(destination => destination.LastName, opt => opt.Ignore())
                    .ForMember(destination => destination.Age, opt => opt.Ignore());


            CreateMap<CreateAccountRequest, Account>()
                 .ForMember(destination => destination.AccountType, source => source.MapFrom(s => s.AccountType))
                 .ForMember(destination => destination.Address, source => source.MapFrom(s => s.Address))
                 .ForMember(destination => destination.City, source => source.MapFrom(s => s.City))
                 .ForMember(destination => destination.Region, source => source.MapFrom(s => s.Region))
                 .ForMember(destination => destination.PostalCode, source => source.MapFrom(s => s.PostalCode));
        }
    }
}
