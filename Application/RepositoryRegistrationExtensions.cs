using Application.Generic_Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Config;
using System.Linq;
using System.Reflection;

namespace Application
{
    public static class RepositoryRegistrationExtensions
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var repositoryInterfaceType = typeof(IGenericRepository<>);
            var repositoryTypes = Assembly.GetExecutingAssembly()
                                          .GetTypes()
                                          .Where(t => t.GetInterfaces()
                                                       .Any(i => i.IsGenericType &&
                                                                 i.GetGenericTypeDefinition() == repositoryInterfaceType));

            foreach (var repositoryType in repositoryTypes)
            {
                var interfaceType = repositoryType.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == repositoryInterfaceType);
                services.AddScoped(interfaceType, repositoryType);
            }

            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
        }
    }
}
