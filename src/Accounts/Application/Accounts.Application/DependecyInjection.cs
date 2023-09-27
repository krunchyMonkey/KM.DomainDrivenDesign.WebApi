using Accounts.Domain.Interfaces;
using Accounts.Domain.Providers;
using Accounts.Domain;
using MediatR.Pipeline;
using Accounts.Application.Mapping.Profiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Accounts.Infrastucture.Context;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Accounts.Application.UseCase.Get;
using Accounts.Application.UseCase.Create;
using Accounts.Application.Handlers;
using Accounts.Application.ViewModel;
using Accounts.Infrastucture;
using Accounts.Application.ViewModel.Accounts;

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
