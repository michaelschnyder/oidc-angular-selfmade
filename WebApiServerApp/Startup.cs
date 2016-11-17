using System.Web.Http;
using Microsoft.Owin;
using Newtonsoft.Json.Serialization;
using Owin;
using WebApiServerApp;
using Microsoft.Owin.Cors;
[assembly: OwinStartup(typeof(Startup))]

namespace WebApiServerApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // Enable CORS
            appBuilder.UseCors(CorsOptions.AllowAll);

            // Web API Configuration & Registration
            var httpConfig = new HttpConfiguration();
            httpConfig.MapHttpAttributeRoutes();

            httpConfig.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            httpConfig.Formatters.Remove(httpConfig.Formatters.XmlFormatter);
            appBuilder.UseWebApi(httpConfig);

        }
    }
}
