using Accounts.Domain.Business.Interfaces;
using Accounts.Domain.Business.Providers;
using MediatR.Pipeline;
using Accounts.Application.Mapping.Profiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Accounts.Infrastucture.Context;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Accounts.Application.Mediator.UseCase.Get;
using Accounts.Application.Mediator.UseCase.Create;
using Accounts.Application.Mediator.Handlers;
using Accounts.Application.ViewModel;
using Accounts.Application.ViewModel.Accounts;
using Accounts.Infrastucture;
using Accounts.Domain.Business;
using Accounts.Application.Mediator.Handlers.CreateAccount;
using Accounts.Application.Mediator.Handlers.FetchAccountById;
using Accounts.Application.Mediator.Handlers.FetchAccountByPersonId;

namespace Accounts.Application.Mediator
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

            services.AddTransient<IRequestHandler<FetchAccountByIdRequest,
                AccountsResponse<AccountVm>>,
                FetchAccountByIdHandler>();

            services.AddTransient<IRequestHandler<FetchAccountByPersonIdRequest,
                AccountsResponse<AccountVm>>,
                FetchAccountByPersonIdHandler>();

            services.AddTransient<IRequestHandler<CreateAccountRequest,
                AccountsResponse<AccountVm>>,
                CreateAccountHandler>();

            services.AddScoped(typeof(IRequestExceptionHandler<FetchAccountByIdRequest,
                                                               AccountsResponse<AccountVm>,
                                                               Exception>),
                                                               typeof(FetchAccountByIdExceptionHandler));

            services.AddScoped(typeof(IRequestExceptionHandler<FetchAccountByPersonIdRequest,
                                                   AccountsResponse<AccountVm>,
                                                   Exception>),
                                                   typeof(FetchAccountByPersonIdExceptionHandler));

            services.AddScoped(typeof(IRequestExceptionHandler<CreateAccountRequest,
                                                   AccountsResponse<AccountVm>,
                                                   Exception>),
                                                   typeof(CreateAccountExceptionHandler));

            return services;
        }
    }
}
