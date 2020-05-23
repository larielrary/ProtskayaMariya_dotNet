using AutoMapper;
using BusinessLayer.Services.Mapper;
using DataLayer;
using DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System.Reflection;

namespace ConsoleApp
{
    public static class Startup
    {
        public static ServiceProvider Configure(IConfigurationRoot configuration)
        {
            var businessLayer = Assembly.Load("BusinessLayer");
            var presentationLayer = Assembly.Load("ConsoleApp");

            return new ServiceCollection()
                .AddTransient<Runner>()
                .AddLogging(loggingBuilder =>
                {
                    loggingBuilder.ClearProviders();
                    loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                    loggingBuilder.AddNLog(configuration);
                })
                .AddDbContext<ServiceStationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
                .AddTransient(typeof(IRepository<>), typeof(GenericRepository<>))
                .Scan(scan => scan
                    .FromAssemblies(businessLayer, presentationLayer)
                    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
                    .AddClasses(classes => classes.Where(type => type.Name.StartsWith("Menu")))
                    .AsSelf()
                    .WithTransientLifetime())
                .AddAutoMapper(typeof(ServiceStationProfile))
                .BuildServiceProvider();
        }
    }
}
