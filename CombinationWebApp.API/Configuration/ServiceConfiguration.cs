using CombinationWebApp.Infrastructure.ContextDb;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;

namespace CombinationWebApp.API.Configuration
{
    public static class ServiceConfiguration
    {
        public static void RegisterControllers(this IServiceCollection services)
        {
            services.AddControllers().PartManager.ApplicationParts.Add(new AssemblyPart(typeof(CombinationWebApp.Presentation.Startup).Assembly));

        }
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
