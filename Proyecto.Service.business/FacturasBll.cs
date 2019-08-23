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
        
        
        public static string SetFactura(Facturas factura)
        {
            try
            {
                var collection = db.GetCollection<BsonDocument>("Facturas");
                BsonDocument document = factura.ToBsonDocument();
                collection.InsertOne(document);

                return "Factura Creada";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<Facturas> GetFacturas()
        {
            try
            {
                List<Facturas> lstFacturas = db.GetCollection<Facturas>("Facturas").Find(_ => true).ToList();

                return lstFacturas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string DeleteFactura(string id)
        {
            try
            {
                db.GetCollection<Facturas>("Facturas").FindOneAndDelete(x => x.CodigoFactura == id);

                return "Factura eliminada";
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static List<Facturas> GetFacturaById(string id)
        {
            try
            {
                List<Facturas> lstFacturas = db.GetCollection<Facturas>("Facturas").Find(x => x.CodigoFactura == id).ToList();

                return lstFacturas;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string PutFacturaById(string id, Facturas x)
        {

            try
            {
                x._id = ObjectId.Parse(id);
                var collection = db.GetCollection<BsonDocument>("Facturas");
                var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
                collection.ReplaceOne(filter, x.ToBsonDocument());

                return "Factura Actualizada";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        
    }
}
