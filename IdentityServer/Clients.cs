using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer4.Models;

namespace IdentityServer
{
    static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            yield return
                new Client
                {
                    ClientName = "Test Client",

                    ClientId = "client",

                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes =
                    {
                        "api1"
                    }
                };
        }
    }
}