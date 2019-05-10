using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Document.Service.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        public static Dictionary<string, string> dictionary = new Dictionary<string, string>();
        public void CreateDocument(string bclCode)
        {
            dictionary[bclCode] = "Document Sent";
        }

        public string GetDocumentStatus(string bclCode)
        {
            if(dictionary.ContainsKey(bclCode))
            {
                return dictionary[bclCode];
            }
            else
            {
                return "Document Not Sent";
            }
        }
    }
}
