using NServiceBus;
using NServiceBus.Logging;
using Prototype.Billing.Service.Service;
using Prototype.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Billing.Service
{
    public class EnrollmentDoneHandler : IHandleMessages<EnrollmentDone>
    {
        private IBillingService billingService;
        private ILog log;
        public EnrollmentDoneHandler(IBillingService billingService, ILog log)
        {
            this.billingService = billingService;
            this.log = log;
        }        
        public Task Handle(EnrollmentDone message, IMessageHandlerContext context)
        {
            log.Info($"Billing Service , BclCode = {message.BclCode} - Billed");
            billingService.AddBilling(message.BclCode);
            return Task.CompletedTask;
        }
    }
}
