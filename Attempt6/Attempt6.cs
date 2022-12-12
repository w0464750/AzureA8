using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Host;
using System.Net.Http;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace Attempt6
{
    public static class Attempt6
    {
        public class EventSample
        {
            public string EventName { get; set; }
            public string EventDesc { get; set; }
            public string EventURL { get; set; }
        }

        [FunctionName("Attempt6")]
        public static async Task<HttpResponseMessage> MyFunction( [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequestMessage req,TraceWriter log)
        {
            var event1 = new EventSample
            {
                EventName = "AAAAA",
                EventDesc = "AAAAA1",
                EventURL = "Image.png"
            };

            var event2 = new EventSample
            {
                EventName = "LoAAAAAem",
                EventDesc = "LoAAAAAem1",
                EventURL = "Image.png"
            };

            var event3 = new EventSample
            {
                EventName = "LAAAAArem",
                EventDesc = "LoreAAAAA1",
                EventURL = "Image.png"
            };

            EventSample[] eventsArr = { event1, event2, event3 };

            // Serialize the object to a JSON string
            var json = JsonConvert.SerializeObject(eventsArr);

            // Return the JSON string in the response body
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
        }
    }
}
