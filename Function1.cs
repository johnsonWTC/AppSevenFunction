using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AppSevenFunction
{
    public static class Function1
    {
        [FunctionName("AppSevenFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "Name/{name}")] HttpRequest req,
            ILogger log, string name)
        {
            User user = new User();
            user.UserName = name;
            UserContext userContext = new UserContext();
            userContext.Add(user);
            userContext.SaveChanges();
            return new OkObjectResult(user);
        }
    }
}
