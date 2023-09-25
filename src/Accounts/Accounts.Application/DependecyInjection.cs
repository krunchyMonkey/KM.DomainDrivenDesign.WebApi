using Accounts.Domain.Interfaces;
using Accounts.Domain.Providers;
using Accounts.Domain;
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
using Accounts.Application.Interfaces;
using System.Reflection;

namespace Accounts.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddAccountsServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddAutoMapper(typeof(AccountsProfile));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            
            services.AddDbContextPool<KrunchypaymentsContext>(o =>
                 o.UseSqlServer("Server=.,1433;Database=krunchypayments;User Id=SA;Password=Arcsin27$;TrustServerCertificate=True;"));

            services.AddScoped<IAccountUnitOfWork, AccountsUnitOfWork>();
            services.AddScoped<IAccountDomain, AccountDomain>();
            services.AddScoped<IAccountProvider, AccountProvider>();

            services.AddTransient<IRequestHandler<FetchAccountById,
                AccountsResponse<AccountVm>>,
                FetchAccountByIdHandler>();

            //services.AddTransient(typeof(IRequestExceptionHandler<FetchAccountById,
            //                                                   AccountsResponse<AccountVm>,
            //                                                   Exception>),
            //                                                   typeof(FetchAccountByIdExceptionHandler));

            return services;
        }
    }
}
