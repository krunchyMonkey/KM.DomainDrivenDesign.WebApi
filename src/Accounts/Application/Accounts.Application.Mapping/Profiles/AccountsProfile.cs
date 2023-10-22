using Accounts.Domain.Model;
using Accounts.Application.ViewModel.Accounts;
using Accounts.Application.ViewModel.Requests;
using AutoMapper;

namespace Accounts.Application.Mapping.Profiles
{
    public class AccountsProfile : Profile
    {
        public AccountsProfile()
        {
            Build();
        }

        public void Build()
        {
            BuildCore();
            BuildCommandReqests();
        }

        public void BuildCore() 
        {
            CreateMap<Account, AccountVm>();
            CreateMap<PaymentMethod, PaymentMethodVm>();
            CreateMap<Person, PersonVm>();
        }

        public void BuildCommandReqests() 
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
