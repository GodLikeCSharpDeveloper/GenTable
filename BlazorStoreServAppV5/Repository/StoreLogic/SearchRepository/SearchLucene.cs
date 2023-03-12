using System.Security.Policy;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Core;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Microsoft.AspNetCore.Http.HttpResults;
using Directory = Lucene.Net.Store.Directory;
using Lucene.Net.Index.Extensions;
using Lucene.Net.Search.Spell;
using Lucene.Net.Util;

namespace BlazorStoreServAppV5.Repository.StoreLogic.SearchRepository;

public class SearchLucene : ISearchLucene,IDisposable
{
    private string path;
    private IndexWriter indexWritter;
    private FSDirectory indexDirectory;
    private StandardAnalyzer analyzer;
    private IndexWriterConfig indexConfig;
    private SpellChecker spellChecker;
    public SearchLucene(string path)
    {
        this.path = path;
    }

    public void IndexWriterCreating()
    {
        var idDirectory = Path.Combine(Environment.CurrentDirectory, path);
        indexDirectory = FSDirectory.Open(idDirectory);
        analyzer = new StandardAnalyzer(LuceneVersion.LUCENE_48);
        indexConfig = new IndexWriterConfig(LuceneVersion.LUCENE_48, analyzer)
        {
            OpenMode = OpenMode.CREATE
        };
        indexWritter = new IndexWriter(indexDirectory, indexConfig);
    }

    public List<string> Search(string searchTerm)
    {
        if (string.IsNullOrEmpty(searchTerm)) return new List<string>();
        var spellDir = Path.Combine(Environment.CurrentDirectory, "/data/spell");
        var spellcheckerDirectory = FSDirectory.Open(spellDir);
        spellChecker = new SpellChecker(spellcheckerDirectory);
        var indexReader = DirectoryReader.Open(indexDirectory);
        spellChecker.IndexDictionary(new LuceneDictionary(indexReader,"name"), new IndexWriterConfig(LuceneVersion.LUCENE_48, new StandardAnalyzer(LuceneVersion.LUCENE_48)), true);
        string[] queryWords = searchTerm.Split(' ');
        for (int i = 0; i < queryWords.Length; i++)
        {
            string[] suggestions = spellChecker.SuggestSimilar(queryWords[i], 1);
            if (suggestions.Length > 0)
            {
                queryWords[i] = suggestions[0];
            }
        }
        spellcheckerDirectory.Dispose();
        string correctedSearchTerm = string.Join(" ", queryWords);
        var resultsList = new List<string>();
        
        var indexSearcher = new IndexSearcher(indexReader);
        var queryParser = new MultiFieldQueryParser(LuceneVersion.LUCENE_48, new string[]{"name", "cat"}, analyzer);
        var query = queryParser.Parse(string.Join(" ", queryWords)+"*");
        var topDocs = indexSearcher.Search(query,null, 10);
        foreach (var topDoc in topDocs.ScoreDocs)
        {
            var doc = indexSearcher.Doc(topDoc.Doc);
            resultsList.Add(doc.Get("name","cat"));
        }
        indexReader.Dispose();
        return resultsList;
    }
    public void AddDocument(Document doc)
    {
        
        indexWritter.AddDocument(doc);
        indexWritter.ForceMerge(1);
        indexWritter.Commit();
        
    }

    public void Dispose()
    {
        indexWritter.Dispose();

    }
}