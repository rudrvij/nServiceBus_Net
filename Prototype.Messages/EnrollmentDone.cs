using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Messages
{
    public class EnrollmentDone: IEvent
    {

        public string BclCode { get; set; }
    }
}
