
using Consulting.Domains.MongoDb.Repositories;

namespace Consulting.Domains.MongoDb.Service
{
    public class ExceptionLogService
    {
        private IExceptionLogRepository exceptionLogRepository;

        public ExceptionLogService(IExceptionLogRepository _exceptionLogRepository)
        {
            exceptionLogRepository = _exceptionLogRepository;
        }

        public void AddExceptionLog(ExceptionLog exceptionLog)
        {
            exceptionLogRepository.Insert(exceptionLog);
        }

    }
}
