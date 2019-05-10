using NServiceBus;
using NServiceBus.Logging;
using Prototype.Enrollment.Service.Repository;
using Prototype.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Enrollment.Service
{
    public class CreateEnrollmentHandler : IHandleMessages<CreateEnrollment>
    {        
        private IEnrollmentService svc;
        private ILog log;

        public CreateEnrollmentHandler(IEnrollmentService svc, ILog log)
        {
            this.svc = svc;
            this.log = log;
        }

        public Task Handle(CreateEnrollment message, IMessageHandlerContext context)
        {
            log.Info($"Create ENrollment Handler, BclCode = {message.BclCode} ");
            
            //Create Enrollment and Publish the Event
            svc.CompleteEnrollment(message.BclCode);

            var enrollmentDoneEvent = new EnrollmentDone() { BclCode = message.BclCode };            
            return context.Publish(enrollmentDoneEvent);
        }
    }
}
