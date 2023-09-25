using Accounts.Domain;
using Accounts.Domain.Interfaces;
using Accounts.Domain.Models;
using Accounts.Domain.Services;
using Accounts.Infrastucture;
using Accounts.Infrastucture.Context;
using Accounts.Infrastucture.Repository;
using Microsoft.EntityFrameworkCore;

namespace Accounts.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Services

            services.AddMvc();

            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            
            services.AddDbContextPool<KrunchypaymentsContext>(o => 
            o.UseSqlServer("Server=.,1433;Database=krunchypayments;User Id=SA;Password=Arcsin27$;TrustServerCertificate=True;"));

            services.AddScoped<IRepository<Account>, AccountRepository>()
                .AddScoped(x => new Lazy<IRepository<Account>>(() => x.GetRequiredService<IRepository<Account>>()));

            services.AddScoped<IRepository<Person>, PersonRepository>()
                .AddScoped(x => new Lazy<IRepository<Person>>(() => x.GetRequiredService<IRepository<Person>>()));

            services.AddScoped<IRepository<PaymentMethod>, PaymentMethodRepository>()
              .AddScoped(x => new Lazy<IRepository<PaymentMethod>>(() => x.GetRequiredService<IRepository<PaymentMethod>>()));

            services.AddScoped<IAccountUnitOfWork, AccountsUnitOfWork>();
            services.AddScoped<IAccountDomain, AccountDomain>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
