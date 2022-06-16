using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace DataAccessLayer.Extensions
{
    public static class DbContextConfigurator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ToDoDbContext>(ctx =>
            {
                ctx.UseSqlServer(connection, providerOptions => providerOptions.EnableRetryOnFailure());
            });
            return services;
        }
        
    }
}
