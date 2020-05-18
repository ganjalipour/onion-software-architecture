using Consulting.Domains.MongoDb;
using Consulting.Domains.MongoDb.Repositories;
using Consulting.Infrastructure.Data.Repositories.MongoDbManagment;
using System.Collections.Generic;

namespace Consulting.Infrastructure.Core.Data.Repositories.MongoDbManagment
{
    public class AuditLogRepository : IAuditLogRepository
    {
        private MongoDBManager MongoDBManager;
        public AuditLogRepository(MongoDBManager _mongoDBManager)
        {
            MongoDBManager = _mongoDBManager;
        }

        public void Insert(AuditLog auditLog)
        {
            MongoDBManager.insert(auditLog);
        }

        public void InsertMany(List<AuditLog> auditLogList)
        {
            MongoDBManager.insertMany<AuditLog>(auditLogList);
        }
    }
}
