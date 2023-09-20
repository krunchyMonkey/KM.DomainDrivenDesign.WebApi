using Accounts.Infrastucture.Context;
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
            services.AddDbContextPool<CustomDbContext>(o => 
            o.UseSqlServer("Server=.,1433;Database=krunchypayments;User Id=SA;Password=Arcsin27$;TrustServerCertificate=True;"));
            // services.AddScoped<IKrunchyPaymentsRepository, KrunchyPaymentsRepository>();
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
