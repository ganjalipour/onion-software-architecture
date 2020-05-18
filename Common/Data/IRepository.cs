using Consulting.Common.Dto;
using Consulting.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Consulting.Common.Data
{
    public interface IRepository<TEntity> where TEntity: Entity
    {
        Task<TEntity> FindAsync(params object[] keys);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        Task<ICollection<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRange(List<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity, object key);
        Task RemoveAsync(params object[] keys);
        Task<int> SaveAsync();
        Task<int> CountAsync();
        void Dispose();
        IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<IEnumerable<TEntity>> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<IEnumerable<TEntity>> GetAllIncluding(params Expression<Func<TEntity, Entity>>[] includeProperties);
        Task<TEntity> FindByFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> filterQuery(Object filterDto);
    }
}
