using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Service.Data
{
    public class MongoConnection
    {
        private static MongoConnection connection = null;
        private static IMongoClient client;
        private static IMongoDatabase databse;

        protected MongoConnection()
        {

        }

        public IMongoClient ConnectionCreate
        {
            get { return client; }
        }

        public IMongoDatabase DatabaseInstance
        {
            get { return databse; }
        }

        private static string ConnectionString() {
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            return connectionString;
        }

        private static string GetDatabase()
        {
            string database = ConfigurationManager.AppSettings["Database"];
            return database;
        }



        public static MongoConnection Connection
        {
            get
            {
                if (connection == null)
                    connection = new MongoConnection();

                client = new MongoClient(ConnectionString());
                databse = client.GetDatabase(GetDatabase());

                return connection;                
            }
        }
    }
}
