using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Enrollment.Service.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        public static Dictionary<string, string> dictionary = new Dictionary<string, string>();
        public void CreateEnrollment(string bclCode)
        {
            if (dictionary.ContainsKey(bclCode))
            {
                dictionary[bclCode] = "Done";
            }
            else
            {
                dictionary.Add(bclCode, "Done");
            }
        }

        public string GetEnrollmentStatus(string bclCode)
        {
            if(dictionary.ContainsKey(bclCode))
            {
                return dictionary[bclCode];
            }
            else
            {
                return "Not Started";
            }
        }
    }
}
