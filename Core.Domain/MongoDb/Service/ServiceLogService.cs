using Consulting.Domains.MongoDb;
using Consulting.Domains.MongoDb.Repositories;

namespace Consulting.Domains.Core.MongoDb.Service
{
    public class ServiceLogService
    {
        private IServiceLogRepository serviceLogRepository;

        public ServiceLogService(IServiceLogRepository _serviceLogRepository)
        {
            serviceLogRepository = _serviceLogRepository;
        }

        public void AddServiceLog(ServiceLog serviceLog)
        {
            serviceLogRepository.Insert(serviceLog);
        }

    }
}
