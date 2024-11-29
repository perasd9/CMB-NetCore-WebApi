namespace CombinationWebApp.API.Database.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IAccountRepository AccountRepository { get;}
        public ICategoryRepository CategoryRepository { get;}
        public IUserRepository UserRepository { get;}
        public ITransactionRepository TransactionRepository { get; }

        public Task SaveChanges();
    }
}
