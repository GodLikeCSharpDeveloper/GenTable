using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Microsoft.AspNetCore.Http.HttpResults;
using Directory = Lucene.Net.Store.Directory;
using Lucene.Net.Index.Extensions;
using Lucene.Net.Util;

namespace BlazorStoreServAppV5.Repository.StoreLogic.SearchRepository;

public class SearchLucene : ISearchLucene, IDisposable
{
    private FSDirectory indexDir;
    private Analyzer analyzer;
    private IndexWriter writer;

    public SearchLucene(string indexPath)
    {
        var path = Path.Combine(Environment.CurrentDirectory, indexPath);
        indexDir = FSDirectory.Open(path);
        analyzer = new StandardAnalyzer(Lucene.Net.Util.LuceneVersion.LUCENE_48);
        var config = new IndexWriterConfig(Lucene.Net.Util.LuceneVersion.LUCENE_48, analyzer);
        writer = new IndexWriter(indexDir, new IndexWriterConfig(LuceneVersion.LUCENE_48, analyzer));
    }

    public void AddDocument(Document doc)
    {
        writer.AddDocument(doc);
    }

    public void Commiting()
    {
        writer.Commit();
    }

    public List<Document> Search(string searchTerm)
    {
        if (!string.IsNullOrEmpty(searchTerm))
        {
            var indexReader = DirectoryReader.Open(indexDir);
            var searcher = new IndexSearcher(indexReader);
            var queryParser = new QueryParser(Lucene.Net.Util.LuceneVersion.LUCENE_48, "name", analyzer);
            var query = queryParser.Parse(searchTerm+"*");
            BooleanQuery andQuery = new BooleanQuery();
            andQuery.Add(query, Occur.MUST);
            var hits = searcher.Search(andQuery, 100).ScoreDocs;
            var hc = hits.Length;
            var searchResults = new List<Document>();
            foreach (var hit in hits) 
                searchResults.Add(searcher.Doc(hit.Doc));
            return searchResults;
        }
        return new List<Document>();    
    }
    public void Dispose()
    {
        writer.Dispose();
        analyzer.Dispose();
        indexDir.Dispose();
    }
}