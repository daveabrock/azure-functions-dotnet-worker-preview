using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace FunctionApp
{
    public static class Function3
    {

        [FunctionName("Function3")]
        public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequestData req,
            [Queue("functionstesting2", Connection = "AzureWebJobsStorage")] OutputBinding<string> name)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteString("Success!!");

            name.SetValue("some name");

            return response;
        }
    }

}
