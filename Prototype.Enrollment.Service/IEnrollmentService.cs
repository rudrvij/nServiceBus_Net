using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Enrollment.Service
{
    public interface IEnrollmentService
    {
        void CompleteEnrollment(string bclCode);

        string GetEnrollmentStatus(string bclCode);

    }
}
