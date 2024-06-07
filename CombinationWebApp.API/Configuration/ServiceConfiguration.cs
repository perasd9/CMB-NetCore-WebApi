using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace CombinationWebApp.API.Configuration
{
    public static class ServiceConfiguration
    {
        public static void RegisterControllers(this IServiceCollection services)
        {
            services.AddControllers().PartManager.ApplicationParts.Add(new AssemblyPart(typeof(CombinationWebApp.Presentation.Startup).Assembly));

        }
    }
}
