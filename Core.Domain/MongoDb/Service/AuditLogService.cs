
using Consulting.Domains.MongoDb.Repositories;

namespace Consulting.Domains.MongoDb.Service
{
    public class AuditLogService
    {
        private IAuditLogRepository auditLogRepository;

        public AuditLogService(IAuditLogRepository _auditLogRepository)
        {
            auditLogRepository = _auditLogRepository;
        }

        public void AddServiceLog(AuditLog auditLog)
        {
            auditLogRepository.Insert(auditLog);
        }

    }
}
