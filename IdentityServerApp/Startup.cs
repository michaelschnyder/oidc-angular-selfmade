using IdentityServer3.Core.Configuration;
using IdentityServerApp.Config;
using IdentityServerApp.Store;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(IdentityServerApp.Startup))]

namespace IdentityServerApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var factory = new IdentityServerServiceFactory();
            factory
                .UseInMemoryClients(Clients.Get())
                .UseInMemoryScopes(Scopes.Get())
                .UseInMemoryUsers(Users.Get());

            var options = new IdentityServerOptions
            {
                SiteName = "IdentityServer",
                Factory = factory,
                RequireSsl = false,
                SigningCertificate = Certificate.Get(),
            };

            appBuilder.UseIdentityServer(options);
        
        }
    }
}
