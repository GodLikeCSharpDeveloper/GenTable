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
        config.OpenMode = OpenMode.CREATE;
        writer = new IndexWriter(indexDir, new IndexWriterConfig(LuceneVersion.LUCENE_48, analyzer));
    }

    public void AddDocument(Document doc)
    {
        writer.AddDocument(doc);
        writer.Commit();
    }

    public List<string> Search(string searchTerm)
    {
        if (!string.IsNullOrEmpty(searchTerm))
        {
            
            var indexReader = DirectoryReader.Open(indexDir);
            var searcher = new IndexSearcher(indexReader);
            var queryParser = new QueryParser(Lucene.Net.Util.LuceneVersion.LUCENE_48, "name", analyzer);
            var query = queryParser.Parse(searchTerm+"*");
            var hits = searcher.Search(query, 10);
            var hc = hits;
            var searchResults = new List<string>();
            for (int i = 0; i < hits.TotalHits; i++)
            {
                //read back a doc from results
                Document resultDoc = searcher.Doc(hits.ScoreDocs[i].Doc);

                string content = resultDoc.Get("name");
                searchResults.Add(content);
            }
          
            return searchResults;
        }
        return new List<string>();    
    }
    public void Dispose()
    {
        writer.Dispose();
        //analyzer.Dispose();
        //indexDir.Dispose();
    }
}