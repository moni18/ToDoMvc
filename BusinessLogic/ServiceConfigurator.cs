using Common.Mappings;
using Microsoft.Extensions.DependencyInjection;


namespace BusinessLogic
{
    public static class ServiceConfigurator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ToDoService>();

            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            return services;
        }
    }
}
