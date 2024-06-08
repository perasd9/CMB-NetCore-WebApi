using CombinationWebApp.Core.Model;
using CombinationWebApp.Infrastructure.Context.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationWebApp.Infrastructure.ContextDb
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get;}
        public DbSet<User> Users { get;}
        public DbSet<Transaction> Transactions { get;}
        public DbSet<Category> Categories { get;}

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
