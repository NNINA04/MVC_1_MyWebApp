using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Common.BusinessLogic.DataBases;
using Common.Interfaces;
using Common.BusinessLogic;

namespace MyWebApp
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = _configuration.GetConnectionString("VisitsDB");

            services.AddDbContext<VisitsDBContext>(options => options.UseNpgsql(connectionString,
                x => x.MigrationsAssembly("Common")));

            services.AddScoped<IVisitorInfoRepository, SQLVisitorInfoRepository>();

            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
