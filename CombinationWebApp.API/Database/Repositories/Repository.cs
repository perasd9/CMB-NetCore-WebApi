using CombinationWebApp.API.Database.Context;
using CombinationWebApp.API.Database.Interfaces.Abstraction;
using System.Linq.Expressions;

namespace CombinationWebApp.API.Database.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll() => _context.Set<TEntity>();
        public IQueryable<TEntity> GetBySearch(Expression<Func<TEntity, bool>> expression) => _context.Set<TEntity>().Where(expression);
        public void Save(TEntity entity) => _context.Add(entity);
        public void Update(TEntity entity) => _context.Update(entity);
        public void Delete(TEntity entity) => _context.Remove(entity);
    }
}
