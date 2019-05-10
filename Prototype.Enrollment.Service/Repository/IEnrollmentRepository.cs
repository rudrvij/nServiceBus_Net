using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Enrollment.Service.Repository
{
    public interface IEnrollmentRepository
    {
        void CreateEnrollment(string bclCode);
        string GetEnrollmentStatus(string bclCode);
    }
}
