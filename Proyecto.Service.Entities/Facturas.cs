using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Service.Entities
{
    public class Facturas
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public string CodigoFactura { get; set; }
        public string Cliente { get; set; }
        public string Ciudad { get; set; }
        public string Nit { get; set; }
        public double TotalFactura { get; set; }
        public double SubTotal { get; set; }
        public double Iva { get; set; }
        public double Retencion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; }
        public bool Pagada { get; set; }
        public DateTime FechaPago { get; set; }
    }
}
