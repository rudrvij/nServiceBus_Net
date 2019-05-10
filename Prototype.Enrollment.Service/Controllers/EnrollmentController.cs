using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using Prototype.Messages;

namespace Prototype.Enrollment.Service.Controllers
{
    [Route("api/[controller]")]
    public class EnrollmentController : Controller
    {
        private IMessageSession messageSession;
        private IEnrollmentService enrollmentService;
        public EnrollmentController(IMessageSession messageSession, IEnrollmentService enrollmentService)
        {
            this.messageSession = messageSession;
            this.enrollmentService = enrollmentService;
        }
        [HttpPost]
        public async Task<string> Post([FromBody]Enrollment doc)
        {
            var message = new EnrollmentDone() { BclCode = doc.BclCode };

            enrollmentService.CompleteEnrollment(doc.BclCode);

            await messageSession.Publish(message).ConfigureAwait(false);
            return "Enrollment donbe";
            
        }
        [HttpGet("{bclCode}")]
        public string Get(string bclCode)
        {
            return enrollmentService.GetEnrollmentStatus(bclCode);

        }

    }
}