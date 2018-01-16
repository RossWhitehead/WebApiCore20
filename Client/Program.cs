using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;

namespace Client
{
    class Program
    {
        public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        private static async Task MainAsync()
        {
            //// discover endpoints from metadata
            //var discoveryClient = new DiscoveryClient("http://localhost:5000");
            //discoveryClient.Policy.RequireHttps = false;

            //var disco = await discoveryClient.GetAsync();

            //if (disco.IsError)
            //{
            //    Console.WriteLine(disco.Error);
            //    Console.ReadKey();
            //    return;
            //}

            // request token
            var tokenClient = new TokenClient("http://localhost:5000/connect/token", "client", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                Console.ReadKey();
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");

            // call api
            var httpClient = new HttpClient();
            httpClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await httpClient.GetAsync("http://localhost:5001/identity");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }

            Console.ReadKey();
        }
    }
}
