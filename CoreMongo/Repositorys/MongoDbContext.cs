using CoreMongo.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace CoreMongo.Repositorys
{
    public class MongoDbContext
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }
        public IMongoDatabase Database { get; }

        public MongoDbContext()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                if (IsSSL)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                }
                var mongoClient = new MongoClient(settings);
                Database = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }

        public IMongoCollection<Nota> Notas
        {
            get
            {
                return Database.GetCollection<Nota>("Notas");
            }
        }

        public IMongoCollection<BsonDocument> NotasDocs
        {
            get
            {
                return Database.GetCollection<BsonDocument>("Notasss");
            }
        }
    }
}