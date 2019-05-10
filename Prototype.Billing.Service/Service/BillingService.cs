using Prototype.Billing.Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Billing.Service.Service
{
    public class BillingService : IBillingService
    {
        private IBillingRepository repository;
        public BillingService(IBillingRepository billingRepository)
        {
            this.repository = billingRepository;
        }
        public void AddBilling(string bclCode)
        {
            repository.AddBilling(bclCode);
        }

        public string GetBillingStatus(string bclCode)
        {
            return repository.GetBillingStatus(bclCode);
        }
    }
}
