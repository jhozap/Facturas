using System.Web.Http;
using WebActivatorEx;
using Proyecto.Service.Api;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Proyecto.Service.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Proyecto.Service.Api");
                        c.IncludeXmlComments(string.Format(@"{0}\bin\Proyecto.Service.Api.xml",
                                          System.AppDomain.CurrentDomain.BaseDirectory));
                    })
                .EnableSwaggerUi();
        }
    }
}
