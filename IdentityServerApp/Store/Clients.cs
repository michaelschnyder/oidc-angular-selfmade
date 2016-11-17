using System.Collections.Generic;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;

namespace IdentityServerApp.Store
{
    public class Clients
    {
        public static List<Client> Get()
        {
            return new List<Client>
            {
                // JavaScript-Client: Implicit Flow, aka as the Client-Side Flow
                new Client
                {
                    ClientName = "My App",
                    ClientId = "myAppId1234567890",
                    Flow = Flows.Implicit,

                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.Profile,
                        Constants.StandardScopes.Email,
                    },

                    ClientUri = "https://webapp.amazing.ctd:8080",

                    RequireConsent = true,
                    AllowRememberConsent = true,
                    
                    RedirectUris = new List<string>
                    {
                        "http://webapp.amazing.ctd:8000/#/callback/login",
                    },

                    //AllowedCorsOrigins = new List<string>
                    //{
                    //    "http://webapp.amazing.ctd:8000/#/secrets"
                    //},
                },
            };
        }
    }
}