using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using Prototype.Messages;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace API.Gateway.Controllers
{
    [Route("api/[controller]")]
    public class EnrollmentController : Controller
    {
        private IMessageSession messageSession;
        public EnrollmentController(IMessageSession messageSession)
        {
            this.messageSession = messageSession;
        }
        public async Task<string> Post([FromBody]EnrollmentRequest request)
        {
            var message = new CreateEnrollment() { BclCode = request.BclCode };
            await messageSession.Send(message).ConfigureAwait(false);

            return "Create Enrollment Command";
        }
        [HttpGet("{bclCode}")]
        public string Get(string bclCode)
        {           
            string result1 = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56888/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Enrollment/"+bclCode);
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