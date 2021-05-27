using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Web.Http;

namespace Demo.Api
{
    public static class StatusFullEndpoint
    {
        [FunctionName("StatusFull")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "status/full")] HttpRequest req, ILogger log)
        {
            // Get cached health check status
            var health = HealthCheck.Current();
            if (!health.IsOK)
            {
                var result = new ObjectResult(health);
                result.StatusCode = 500;
                return result;
            }
            
            return new OkObjectResult(health);
        }
    }
}
