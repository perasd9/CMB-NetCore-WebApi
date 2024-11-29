using CombinationWebApp.API.Database.Context;
using CombinationWebApp.API.Database.Interfaces;
using CombinationWebApp.API.Database.Interfaces.UnitOfWork;
using CombinationWebApp.API.Database.Repositories;

namespace CombinationWebApp.Infrastructure.Repositories.Unit_Of_Work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        private readonly IAccountRepository _accountRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserRepository _userRepository;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;

            _accountRepository = new AccountRepository(_context);
            _categoryRepository = new CategoryRepository(_context);
            _transactionRepository = new TransactionRepository(_context);
            _userRepository = new UserRepository(_context);
        }
        public IAccountRepository AccountRepository => _accountRepository;

        public ICategoryRepository CategoryRepository => _categoryRepository;

        public IUserRepository UserRepository => _userRepository;

        public ITransactionRepository TransactionRepository => _transactionRepository;

        public async Task SaveChanges() => await _context.SaveChangesAsync();

    }
}
