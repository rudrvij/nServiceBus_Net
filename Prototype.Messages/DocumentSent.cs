using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Messages
{
    public class DocumentSent : IEvent
    {
        public string BclCode { get; set; }
        public string DocumentType { get; set; }
    }
}
