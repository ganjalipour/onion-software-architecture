using Consulting.Common.Model;
using MongoDB.Bson;
using System;

namespace Consulting.Domains.MongoDb
{
    public class ExceptionLog: Entity
    {        
        public ObjectId id { get; set; }
        public Exception exception { get; set; }
        public string message { get; set; }
        public string stackTrace { get; set; }
        public DateTime date { get; set; }
        public string ipAddress { get; set; }

    }
}