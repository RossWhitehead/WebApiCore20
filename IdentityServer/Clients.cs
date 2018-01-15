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
                    ClientId = "testclient",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,

                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets = new List<Secret>
                    {
                        new Secret("F621F470-9731-4A25-80EF-67A6F7C5F4B8".Sha256())
                    },

                    AllowedScopes = new List<string>
                    {
                        "WebApiCore20"
                    }
                };
        }
    }
}