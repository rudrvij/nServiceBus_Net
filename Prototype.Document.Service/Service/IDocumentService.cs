namespace Prototype.Document.Service
{
    public interface IDocumentService
    {
        void AddDocument(string bclCode);

        string GetDocumentStatus(string bclCode);

    }
}
