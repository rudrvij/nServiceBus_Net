using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prototype.Billing.Service.Service;

namespace Prototype.Billing.Service.Controllers
{
    [Route("api/[controller]")]
    public class BillingController : Controller
    {
        private IBillingService svc;
        public BillingController(IBillingService svc)
        {
            this.svc = svc;
        }
        [HttpPost]
        public void Post([FromBody]Invoice doc)
        {            
            svc.AddBilling(doc.BclCode);
        }
        [HttpGet("{bclCode}")]
        public string Get(string bclCode)
        {
            return svc.GetBillingStatus(bclCode);

        }
    }
}