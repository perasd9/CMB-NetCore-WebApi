using CombinationWebApp.API.Database.Context.Configuration;
using CombinationWebApp.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CombinationWebApp.API.Database.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Account>? Accounts { get; }
        public DbSet<User>? Users { get; }
        public DbSet<Transaction>? Transactions { get; }
        public DbSet<Category>? Categories { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AccountConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new TransactionConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
        }
    }
}
