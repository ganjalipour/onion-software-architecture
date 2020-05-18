using Consulting.Common.Model;
using MongoDB.Bson;
using System;

namespace Consulting.Domains.MongoDb
{
    public class ServiceLog : Entity
    {        
        public ObjectId id { get; set; }
        public string requestMethod { get; set; }
        public string requestUri { get; set; }
        public DateTime requestDate { get; set; }
        public string requestContentType { get; set; }
        public object requestContent { get; set; }
        public int responseStatusCode { get; set; }
        public DateTime responseDate { get; set; }
        public string responseContentType { get; set; }
        public object responseContent { get; set; }        
        public int userID { get; set; }
        public string cellNumber { get; set; }
        public string ipAddress { get; set; }
    }
}