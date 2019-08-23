using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Proyecto.Service.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Service.business
{
    public class FacturasBll
    {

        // Variables
        private static IMongoClient client = new MongoClient(ConfigurationManager.AppSettings["ConnectionString"]);
        private static IMongoDatabase db = client.GetDatabase(ConfigurationManager.AppSettings["Database"]);
        
        
        public static void SetFactura(Facturas factura)
        {            
            var collection = db.GetCollection<BsonDocument>("Facturas");
            BsonDocument document = factura.ToBsonDocument();
            collection.InsertOne(document);
        }


        public static List<Facturas> GetFacturas()
        {
            List<Facturas> lstFacturas = db.GetCollection<Facturas>("Facturas").Find(_ => true).ToList();   

            return lstFacturas;

        }

        public static string DeleteFactura(string id)
        {
            db.GetCollection<Facturas>("Facturas").FindOneAndDelete( x => x.CodigoFactura == id);

            return "Factura eliminada";

        }

        public static List<Facturas> GetFacturaById(string id)
        {
            List<Facturas> lstFacturas = db.GetCollection<Facturas>("Facturas").Find(x => x.CodigoFactura == id).ToList();

            return lstFacturas;

        }

        public static object PutFacturaById(string id, Facturas x)
        {
            var filter = Builders<Facturas>.Filter.Eq(s => s.CodigoFactura, id);
            var lstFacturas = db.GetCollection<Facturas>("Facturas").ReplaceOneAsync(filter, x);

            return lstFacturas;

            //MyType myObject; // passed in 
            //var filter = Builders<MyType>.Filter.Eq(s => s.Id, id);
            //var result = await collection.ReplaceOneAsync(filter, myObject)

        }

        //private static List<Facturas> Json2List(IMongoCollection<BsonDocument> collection)
        //{
        //    List<Facturas> lstResult = new List<Facturas>();

        //    return lstResult;
        //}

        //public static Facturas Json2Object()
        //{

        //}
    }
}
