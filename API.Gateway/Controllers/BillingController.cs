using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using System.Net.Http;

namespace API.Gateway.Controllers
{
    [Route("api/[controller]")]
    public class BillingController : Controller
    {
        private IMessageSession messageSession;
        public BillingController(IMessageSession messageSession)
        {
            this.messageSession = messageSession;
        }

        [HttpGet("{bclCode}")]
        public string Get(string bclCode)
        {
            string result1 = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56866/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Billing/" + bclCode);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var task = result.Content.ReadAsStringAsync();
                    task.Wait();
                    result1 = task.Result;

                }
                else //web api sent error response 
                {
                    //log response status here..

                }

            }
            return result1;

        }
    }
}