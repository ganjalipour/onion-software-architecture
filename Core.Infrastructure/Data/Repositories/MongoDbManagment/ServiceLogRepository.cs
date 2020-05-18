﻿using Consulting.Domains.MongoDb;
using Consulting.Domains.MongoDb.Repositories;
using Consulting.Infrastructure.Data.Repositories.MongoDbManagment;

namespace Consulting.Infrastructure.Core.Data.Repositories.MongoDbManagment
{
    public class ServiceLogRepository : IServiceLogRepository
    {
        private MongoDBManager MongoDBManager;
        public ServiceLogRepository(MongoDBManager _mongoDBManager)
        {
            MongoDBManager = _mongoDBManager;
        }

        public void Insert(ServiceLog serviceLog)
        {
            MongoDBManager.insert(serviceLog);
        }

    }
}
