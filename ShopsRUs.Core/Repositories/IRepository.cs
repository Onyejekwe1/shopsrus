using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int Id);   
        Task<IEnumerable<TEntity>> GetAllAsync(); 
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        int AddRange(IEnumerable<TEntity> entities);
        TEntity Update(int id, TEntity entity); 
        int Count();

        bool Remove(TEntity entity);
        int RemoveRange(IEnumerable<TEntity> entities);
        bool IsExist(Expression<Func<TEntity, bool>> predicate);
    }
}
