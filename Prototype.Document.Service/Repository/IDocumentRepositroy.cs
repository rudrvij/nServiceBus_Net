using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Document.Service.Repository
{
    public interface IDocumentRepository
    {
        void CreateDocument(string bclCode);

        string GetDocumentStatus(string bclCode);
    }
}
