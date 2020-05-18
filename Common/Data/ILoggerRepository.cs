using Consulting.Common.Model;

namespace Consulting.Common.Data
{
   public interface ILoggerRepository<TEntity> where TEntity : Entity
    {
        void Insert(TEntity entity);
    }
}
