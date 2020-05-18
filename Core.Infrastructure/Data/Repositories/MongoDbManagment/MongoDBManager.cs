using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver.Core.Configuration;
using Microsoft.Extensions.Configuration;

namespace Consulting.Infrastructure.Data.Repositories.MongoDbManagment
{
    public class MongoDBManager
    {
        public MongoDBManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private IMongoClient _client;
        private IConfiguration _configuration;
        private IMongoClient client
        {
            get
            {
                if (_client == null)
                {
                    string con = _configuration.GetConnectionString("MongodbConsultingCnn");
                    _client = new MongoClient(con);
                }
                return _client;
            }
        }

        private IMongoDatabase _database;
        private IMongoDatabase database
        {
            get
            {
                if (_database == null)
                    _database = client.GetDatabase("MicroFunds");
                return _database;
            }
        }

        private IMongoCollection<T> getCollection<T>()
        {
            return database.GetCollection<T>(typeof(T).Name);
        }

        public void insert<T>(T document)
        {

            getCollection<T>().InsertOne(document);
        }

        public void insertMany<T>(List<T> documents)
        {
            getCollection<T>().InsertMany(documents);
        }


        public List<T> find<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return getCollection<T>().Find(expression).ToList();
        }
    }



}