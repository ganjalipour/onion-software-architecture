using Consulting.Domains.MongoDb;
using Consulting.Domains.MongoDb.Repositories;
using Consulting.Infrastructure.Data.Repositories.MongoDbManagment;

namespace Consulting.Infrastructure.Core.Data.Repositories.MongoDbManagment
{
    public class ExceptionLogRepository : IExceptionLogRepository
    {

        private MongoDBManager MongoDBManager;
        public ExceptionLogRepository(MongoDBManager _mongoDBManager)
        {
            MongoDBManager = _mongoDBManager;
        }

        public void Insert(ExceptionLog exceptionLog)
        {
            MongoDBManager.insert(exceptionLog);
        }

    }
}
