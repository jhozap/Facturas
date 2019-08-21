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
            List<Facturas> lstFacturas = db.GetCollection<Facturas>("Facturas").Find("").ToList();   
            



            // = Json2List(collection);
            return null;

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
