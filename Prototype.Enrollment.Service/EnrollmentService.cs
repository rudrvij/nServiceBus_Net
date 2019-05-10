using Prototype.Enrollment.Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Enrollment.Service
{
    public class EnrollmentService:IEnrollmentService
    {
        private IEnrollmentRepository repo;
        public EnrollmentService(IEnrollmentRepository repo)
        {
            this.repo = repo;
        }
        public void CompleteEnrollment(string bclCode)
        {
            repo.CreateEnrollment(bclCode);
        }
        public string GetEnrollmentStatus(string bclCode)
        {
            return repo.GetEnrollmentStatus(bclCode);
        }

    }
}
