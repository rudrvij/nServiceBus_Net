using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Billing.Service.Repository
{
    public class BillingRepository : IBillingRepository
    {
        private static Dictionary<string,string> dictionary = new Dictionary<string,string>();

        public void AddBilling(string bclCode)
        {
            if (dictionary.ContainsKey(bclCode))
            {
                dictionary[bclCode] = "Billed";
            }
            else
            {
                dictionary.Add(bclCode, "Billed");
            }
        }

        public string GetBillingStatus(string bclCode)
        {
            if (dictionary.ContainsKey(bclCode))
            {
                return dictionary[bclCode];
            }
            else
            {
                return "Not Billed";
            }
        }
    }
}
