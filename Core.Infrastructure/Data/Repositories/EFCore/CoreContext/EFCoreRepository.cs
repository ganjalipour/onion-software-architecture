using Consulting.Common.Model;
using Consulting.Common.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Consulting.Infrastructure.Core.Data.Repositories.EFCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System;
using System.Reflection;
using Consulting.Common.Utility;
using Consulting.Common.Dto;
using Consulting.Common.Collections;
using Consulting.Infrastructure.Core.ContextFactory;
using MicroFunds.Common.Utility;

namespace Consulting.Infrastructure.Data.Repositories.EFCore
{
    public abstract class EFCoreRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected AppDBContext Context;
      
        private DbSet<TEntity> _dbSet;

        private bool disposed = false;

        private Expression<Func<TEntity, bool>> finalExpression;

        public EFCoreRepository(IContextProviderFactory contextProvider)
        {
            Context = contextProvider.dbContext;
           _dbSet = Context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> qry = _dbSet;
            if (predicate != null)
                qry = _dbSet.Where(predicate);
            if (orderBy != null)
                qry = orderBy(qry);
            return qry;
        }

        public virtual async Task<IEnumerable<TEntity>> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            var ret = GetQuery(predicate, orderBy);
            await ret.ToListAsync();
            return ret;
        }
        public  IEnumerable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return GetQuery(predicate, orderBy).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllIncluding(params Expression<Func<TEntity, Entity>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = _dbSet;
            foreach (Expression<Func<TEntity, Entity>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<TEntity, Entity>(includeProperty);
            }

            return await queryable.ToListAsync();
        }

        public virtual async Task AddAsync(TEntity entity)
        {         
            await _dbSet.AddAsync(entity);           
        }

        public virtual async Task AddRange(List<TEntity> entities)
        {
            if (entities == null)
                return;

            await _dbSet.AddRangeAsync(entities);
        }

        public virtual async Task RemoveAsync(params object[] keys)
        {
            var fetchedEntity = await _dbSet.FindAsync(keys);
            _dbSet.Remove(fetchedEntity);
        }


        public virtual async Task<TEntity> UpdateAsync(TEntity entity, object key)
        {
            try
            {
                if (entity == null)
                    return null;
                TEntity exist = await _dbSet.FindAsync(key);
                if (exist != null)
                {
                    Context.Entry(exist).CurrentValues.SetValues(entity);
                }
                return exist;
            }
            catch (Exception exe)
            {
                throw exe;
            }      
        }

        public async virtual Task<int> SaveAsync()
        {
            AddTimestamps();
            return await Context.SaveChangesAsync();
        }

        public virtual async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }

        public virtual async Task<TEntity> FindAsync(params object[] keys)
        {
            return await _dbSet.FindAsync(keys);
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _dbSet.Where<TEntity>(predicate);
            return query;
        }

        public virtual async Task<ICollection<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> FindByFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync<TEntity>();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void AddTimestamps()
        {
            var entities = Context.ChangeTracker.Entries().Where(x => x.Entity is Entity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var currentUserId = 1;

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    //entity.Property("CreateDate").CurrentValue = DateTime.Now;
                    entity.Property("CreatedBy").CurrentValue = currentUserId;
                }
                //entity.Property("UpdateDate").CurrentValue = DateTime.Now;
                entity.Property("ModifiedBy").CurrentValue = currentUserId;
            }
        }

        public Task<List<TEntity>> filterQuery(object filterDto)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "p");
            var properties = filterDto.GetType().GetProperties();

            Expression body;
            IQueryable<TEntity> queryable = _dbSet;
            dynamic val;
            foreach (var propertyInfo in properties)
            {
                val = propertyInfo.GetValue(filterDto);
                if (val != null)
                {
                    if (propertyInfo.PropertyType.FullName.Contains("System.Int64"))
                    {
                        body = Expression.Equal(Expression.Property(parameter, propertyInfo.Name), Expression.Constant(val));
                    }
                    else
                    {
                        MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                        body = Expression.Call(Expression.Property(parameter, propertyInfo.Name), method, Expression.Constant(val));
                    }
                    finalExpression = Expression.Lambda<Func<TEntity, bool>>(body, parameter);
                    queryable = queryable.Where(finalExpression);
                }
            }
            return queryable.ToListAsync();
        }

        public IQueryable<T> ApplySorting<T>(BaseFilter filterDto, IQueryable<T> entities, Func<string, string> mapper = null)
        {

            int count = 0;
            if (filterDto.SortDto != null && filterDto.SortDto.Count() > 0 )
            {
                filterDto.SortDto.ForEach(x =>
                {

                    if (x.dir == "asc" && x.dir != null && x.field !=null)
                    {
                        count += 1;
                        if (count > 1)
                            entities = entities.ExtendedOrderBy(mapper == null ? x.field : mapper(x.field) , true);

                        else
                            entities = entities.ExtendedOrderBy(mapper == null ? x.field : mapper(x.field) , false);

                    }
                    else if (x.dir != null && x.field != null)
                    {
                        count += 1;
                        if (count > 1)
                            entities = entities.ExtendedOrderByDescending(x.field, true);
                        else
                            entities = entities.ExtendedOrderByDescending(x.field, false);
                    }

                });
            }
            return entities;
        }
       
    }
}
