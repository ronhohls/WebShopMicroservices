using Common.Behaviours;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using System.Reflection;
using Common.Messaging.MassTransit;

namespace Ordering.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
                config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
            });

            services.AddFeatureManagement();
            services.AddMessageBroker(configuration, Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
