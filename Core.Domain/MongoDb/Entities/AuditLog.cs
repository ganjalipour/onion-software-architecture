using Consulting.Common.Model;
using MongoDB.Bson;
using System;

namespace Consulting.Domains.MongoDb
{
    public class AuditLog: Entity
    {
        public ObjectId id { get; set; }
        public int EntityID { get; set; }
        public string ActionTitle { get; set; }
        public int UserID { get; set; }
        public string ipAddress { get; set; }
        public object BeforeChanged { get; set; }
        public object AfterChanged { get; set; }
        public string ObjectType { get; set; }
        public DateTime OccurrenceDate { get; set; }
    }
}