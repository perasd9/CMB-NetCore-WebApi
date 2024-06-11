using System.Linq.Expressions;

namespace CombinationWebApp.Application.Interfaces.Repositories.Abstraction
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetBySearch(Expression<Func<TEntity, bool>> expression);
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
