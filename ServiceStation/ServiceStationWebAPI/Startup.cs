using AutoMapper;
using BusinessLayer.Services.Mapper;
using DataLayer;
using DataLayer.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace ServiceStationWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ServiceStationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();

            var bl = Assembly.Load("BusinessLayer");

            services
            .AddTransient(typeof(IRepository<>), typeof(GenericRepository<>))
            .Scan(scan => scan
                .FromAssemblies(bl)
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
                .AsSelf()
                .WithTransientLifetime())
            .AddAutoMapper(typeof(ServiceStationProfile));
            services.AddIdentity<IdentityUser, IdentityRole>(options => { options.Password.RequireNonAlphanumeric = false; })
                    .AddEntityFrameworkStores<ServiceStationContext>();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(swagger =>
            {
                swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Store API");
                swagger.RoutePrefix = string.Empty;
            });

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
