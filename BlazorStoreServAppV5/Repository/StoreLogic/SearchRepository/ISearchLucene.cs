using Lucene.Net.Documents;

namespace BlazorStoreServAppV5.Repository.StoreLogic.SearchRepository
{
    public interface ISearchLucene
    {
        public void AddDocument(Document doc);
        public List<string> Search(string searchTerm);
        public void Dispose();
    }
}
