using System.Web.Http;
using WebActivatorEx;
using WebApiTeste;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApiTeste
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.Schemes(new[] { "http", "https" });
                    c.SingleApiVersion("v1", "WebApiTeste");
                    c.IncludeXmlComments(GetXmlCommentsPath());
                })
                .EnableSwaggerUi(c =>
                {
                    c.DocumentTitle("RH Apps Environment");
                    c.DocExpansion(DocExpansion.List);
                });
        }

        private static string GetXmlCommentsPath()
        {
            return string.Format(@"{0}\Docs\WebApiTeste.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
