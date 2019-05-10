using Prototype.Document.Service.Repository;

namespace Prototype.Document.Service
{
    public class DocumentService:IDocumentService
    {
        private IDocumentRepository repo;
        public DocumentService(IDocumentRepository repo)
        {
            this.repo = repo;
        }
        public void AddDocument(string bclCode)
        {
            repo.CreateDocument(bclCode);
        }
        public string GetDocumentStatus(string bclCode)
        {
            return repo.GetDocumentStatus(bclCode);
        }

    }
}
