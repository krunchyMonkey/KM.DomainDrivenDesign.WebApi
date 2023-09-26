using Accounts.Domain.Interfaces;
using Accounts.Domain.Providers;
using Accounts.Domain;
using MediatR.Pipeline;
using Accounts.Infrastucture.Mapping.Profiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounts.Infrastucture;
using Accounts.Infrastucture.Context;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Accounts.Application.UseCase.Get;
using Accounts.Infrastucture.ViewModel;
using Accounts.Infrastucture.ViewModel.Accounts;
using System.Reflection;
using Accounts.Application.UseCase.Create;
using Accounts.Application.Handlers;

namespace Accounts.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddAccountsServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddAutoMapper(typeof(AccountsProfile));
         
            
            services.AddDbContextPool<KrunchypaymentsContext>(o =>
                 o.UseSqlServer("Server=.,1433;Database=krunchypayments;User Id=SA;Password=Arcsin27$;TrustServerCertificate=True;"));

            services.AddScoped<IAccountUnitOfWork, AccountsUnitOfWork>();
            services.AddScoped<IPersonDomain, PersonDomain>();
            services.AddScoped<IAccountDomain, AccountDomain>();
            services.AddScoped<IAccountProvider, AccountProvider>();

            services.AddTransient<IRequestHandler<FetchAccountById,
                AccountsResponse<AccountVm>>,
                FetchAccountByIdHandler>();

            services.AddTransient<IRequestHandler<FetchAccountByPersonId,
                AccountsResponse<AccountVm>>,
                FetchAccountByPersonIdHandler>();

            services.AddTransient<IRequestHandler<CreateAccount,
                AccountsResponse<AccountVm>>,
                CreateAccountHandler>();

            services.AddScoped(typeof(IRequestExceptionHandler<FetchAccountById,
                                                               AccountsResponse<AccountVm>,
                                                               Exception>),
                                                               typeof(FetchAccountByIdExceptionHandler));

            services.AddScoped(typeof(IRequestExceptionHandler<FetchAccountByPersonId,
                                                   AccountsResponse<AccountVm>,
                                                   Exception>),
                                                   typeof(FetchAccountByPersonIdExceptionHandler));

            services.AddScoped(typeof(IRequestExceptionHandler<CreateAccount,
                                                   AccountsResponse<AccountVm>,
                                                   Exception>),
                                                   typeof(CreateAccountExceptionHandler));

            return services;
        }
    }
}
