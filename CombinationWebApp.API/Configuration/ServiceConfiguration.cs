using CombinationWebApp.Application.Interfaces.Repositories;
using CombinationWebApp.Application.Interfaces.Repositories.UnitOfWork;
using CombinationWebApp.Application.Services;
using CombinationWebApp.Infrastructure.ContextDb;
using CombinationWebApp.Infrastructure.Repositories;
using CombinationWebApp.Infrastructure.Repositories.Unit_Of_Work;
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

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<AccountService>();
            services.AddTransient<CategoryService>();
            services.AddTransient<TransactionService>();
            services.AddTransient<UserService>();
        }
    }
}
