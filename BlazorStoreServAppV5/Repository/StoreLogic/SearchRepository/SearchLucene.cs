using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Search.Spell;
using Lucene.Net.Util;

namespace BlazorStoreServAppV5.Repository.StoreLogic.SearchRepository;

public class SearchLucene : ISearchLucene,IDisposable
{
    private readonly string path;
    private IndexWriter _indexWritter;
    private FSDirectory _indexDirectory;
    private StandardAnalyzer _analyzer;
    private IndexWriterConfig _indexConfig;
    private SpellChecker _spellChecker;
    public SearchLucene(string path)
    {
        this.path = path;
    }
    public void IndexWriterCreating()
    {
        var idDirectory = Path.Combine(Environment.CurrentDirectory, path);
        _indexDirectory = FSDirectory.Open(idDirectory);
        _analyzer = new StandardAnalyzer(LuceneVersion.LUCENE_48);
        _indexConfig = new IndexWriterConfig(LuceneVersion.LUCENE_48, _analyzer)
        {
            OpenMode = OpenMode.CREATE
        };
        _indexWritter = new IndexWriter(_indexDirectory, _indexConfig);
    }

    public List<string> Search(string searchTerm)
    {
        if (string.IsNullOrEmpty(searchTerm)) return new List<string>();
        searchTerm = searchTerm.Trim();
        var spellDir = Path.Combine(Environment.CurrentDirectory, "/data/spell");
        var spellcheckerDirectory = FSDirectory.Open(spellDir);
        _spellChecker = new SpellChecker(spellcheckerDirectory);
        var indexReader = DirectoryReader.Open(_indexDirectory);
        _spellChecker.IndexDictionary(new LuceneDictionary(indexReader,"name"), new IndexWriterConfig(LuceneVersion.LUCENE_48, new StandardAnalyzer(LuceneVersion.LUCENE_48)), true);
        string[] queryWords = searchTerm.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < queryWords.Length; i++)
        {
            string[] suggestions = _spellChecker.SuggestSimilar(queryWords[i], 1);
            if (suggestions.Length > 0)
            {
                queryWords[i] = suggestions[0];
            }
        }
        spellcheckerDirectory.Dispose();
        string correctedSearchTerm = string.Join(" ", queryWords);
        var resultsList = new List<string>();
        var indexSearcher = new IndexSearcher(indexReader);
        var queryParser = new MultiFieldQueryParser(LuceneVersion.LUCENE_48, new string[]{"name", "cat"}, _analyzer);
        var query = queryParser.Parse(string.Join(" ", correctedSearchTerm)+"*");
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
        _indexWritter.AddDocument(doc);
        _indexWritter.ForceMerge(1);
        _indexWritter.Commit();
    }

    public void Dispose()
    {
        _indexWritter.Dispose();
    }
}