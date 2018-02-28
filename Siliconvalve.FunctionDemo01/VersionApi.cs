using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace Siliconvalve.FunctionDemo01
{
    /// <summary>
    /// Version API endpoint
    /// </summary>
    /// <remarks>Allows us to test what version of the Functions App is deployed into an environment by making a simple HTTP request.</remarks>
    public static class VersionApi
    {
        [FunctionName("VersionApi")]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "theversion")]HttpRequestMessage req, TraceWriter log)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Assembly.GetExecutingAssembly().GetName().Version.ToString())
            };
        }
    }
}
