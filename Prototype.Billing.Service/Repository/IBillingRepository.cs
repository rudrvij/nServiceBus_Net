using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Billing.Service.Repository
{
    public interface IBillingRepository
    {
        void AddBilling(string bclCode);
        string GetBillingStatus(string bclCode);
    }
}
