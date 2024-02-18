using Application.Interfaces;
using Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Config;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IBlobService, BlobService>();
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddScoped<INotificationService, NotificationService>();
        }
    }
}

