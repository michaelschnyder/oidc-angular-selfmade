using System.Web.Http;
using Microsoft.Owin;
using Newtonsoft.Json.Serialization;
using Owin;
using WebApiServerApp;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using WebApiServerApp.Config;

[assembly: OwinStartup(typeof(Startup))]

namespace WebApiServerApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // Enable JWT Bearer Auth
            appBuilder.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AllowedAudiences = new[] { "myAppId1234567890" },
                AuthenticationMode = AuthenticationMode.Active,
                IssuerSecurityTokenProviders = new[]
                {
                    new X509CertificateSecurityTokenProvider("http://identity.amazing.ctd", Certificate.Get()),
                }
            });

            // Enable CORS, since we are using the API on localhost:8000
            appBuilder.UseCors(CorsOptions.AllowAll);

            // Web API Configuration & Registration
            var httpConfig = new HttpConfiguration();
            httpConfig.MapHttpAttributeRoutes();

            httpConfig.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Prevent ReferenceLoops when serializing current Principal
            httpConfig.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // Disabling XML is good practice
            httpConfig.Formatters.Remove(httpConfig.Formatters.XmlFormatter);
            appBuilder.UseWebApi(httpConfig);

        }
    }
}
