using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using Prototype.Messages;

namespace Prototype.Document.Service.Controllers
{
    [Route("api/[controller]")]
    public class DocumentController : Controller
    {
        private IMessageSession messageSession;
        private IDocumentService svc;
        public DocumentController(IMessageSession messageSession, IDocumentService svc)
        {
            this.messageSession = messageSession;
            this.svc = svc;
        }
  
        [HttpPost]
        public async Task<string> Post([FromBody]Document doc)
        {
            var message = new DocumentSent() { BclCode = doc.BclCode, DocumentType = doc.DocumentType };

            await messageSession.Publish(message).ConfigureAwait(false);

            return "Document Sent Event Published";
            //DocumentService svc = new DocumentService(messageSession);
            //svc.SendDocument(doc);
        }
        [HttpGet("{bclCode}")]
        public string Get(string bclCode)
        {
            return svc.GetDocumentStatus(bclCode);

        }
    }
}