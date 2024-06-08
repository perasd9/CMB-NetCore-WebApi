using CombinationWebApp.Application.Interfaces.Repositories.Abstraction;
using CombinationWebApp.Core.Model.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CombinationWebApp.Infrastructure.Repositories
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {

        public IQueryable<TEntity> GetAll() => 

        public IQueryable<TEntity> GetBySearch(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Save(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

    }
}
