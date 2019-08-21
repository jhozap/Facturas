using Proyecto.Service.business;
using Proyecto.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Proyecto.Service.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Headers")]
    public class FacturasController : ApiController
    {
       
        /// <summary>
        /// Post
        /// </summary>
        /// <param name="factura"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult PostFactura([FromBody] Facturas factura)
        {

            try
            {
                FacturasBll.SetFactura(factura);

                return Ok(true);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetFacturas()
        {

            try
            {
                FacturasBll.GetFacturas();

                return Ok(true);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }






















        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //public IHttpActionResult GetFacturas()
        //{

        //    try
        //    {
        //        var resp = FacturasBll.GetFacturas();                

        //        return Ok(resp);
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError();
        //    }
        //}

    }
}
