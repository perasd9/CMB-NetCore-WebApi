using CombinationWebApp.API.Database.Context;
using CombinationWebApp.API.Database.Interfaces;
using CombinationWebApp.API.Database.Interfaces.UnitOfWork;
using CombinationWebApp.API.Database.Repositories;
using CombinationWebApp.API.Features.Accounts;
using CombinationWebApp.API.Features.Categories;
using CombinationWebApp.API.Features.Transactions;
using CombinationWebApp.API.Features.Users;
using CombinationWebApp.Infrastructure.Repositories.Unit_Of_Work;
using Microsoft.EntityFrameworkCore;

namespace CombinationWebApp.API.Configuration
{
    public static class ServiceConfiguration
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
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
