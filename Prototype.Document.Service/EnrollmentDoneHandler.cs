using NServiceBus;
using NServiceBus.Logging;

using Prototype.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Document.Service
{
    public class EnrollmentDoneHandler : IHandleMessages<EnrollmentDone>
    {
        private IDocumentService svc;
        private ILog log;
        public EnrollmentDoneHandler(IDocumentService svc, ILog log)
        {
            this.svc = svc;
            this.log = log;
        }        
        public Task Handle(EnrollmentDone message, IMessageHandlerContext context)
        {
            log.Info($"Document Service , BclCode = {message.BclCode} - documents sent");
            svc.AddDocument(message.BclCode);
            return Task.CompletedTask;
        }
    }
}
