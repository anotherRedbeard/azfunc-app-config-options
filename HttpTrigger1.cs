using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace Company.Function
{
    public class HttpTrigger1
    {
        private readonly IConfiguration _configuration;

        public HttpTrigger1(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [FunctionName("HttpTrigger1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // Read configuration data
            string keyName = "TestApp:Settings:Message";
            string message = await Task.FromResult(_configuration[keyName]);

            return message != null
                ? (ActionResult)new OkObjectResult(message)
                : new BadRequestObjectResult($"Please create a key-value with the key '{keyName}' in App Configuration.");
        }
    }
}
