using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer4.Models;

namespace IdentityServer
{
    static class ApiResources
    {
        public static IEnumerable<ApiResource> Get()
        {
            yield return
               new ApiResource("api1", "WebApi Core 2.0");
        }
    }
}
