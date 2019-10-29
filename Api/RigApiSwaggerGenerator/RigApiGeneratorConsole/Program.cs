using Ensco.Irma.Oap.Rig.Api;
using Microsoft.Owin.Testing;
using System.IO;

namespace Ensco.Irma.RigApi.Swagger.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var server = TestServer.Create<Startup>())
            {
                var response = server.CreateRequest("/rigapi/swagger/docs/v1").GetAsync().Result;
                var content = response.Content.ReadAsStringAsync().Result;
                File.WriteAllText("swagger.json", content);
            }
        }
    }
}
