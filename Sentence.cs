using System.Text;
using лаба_3_с_.Models;
namespace TextLab.Models;
public class Sentence : Token
{
    public List<Token> Tokens { get; } = new();
    public IEnumerable<Word> Words => Tokens.OfType<Word>();
    public IEnumerable<Punctuation> Punctuations => Tokens.OfType<Punctuation>();
    public int WordCount => Tokens.OfType<Word>().Count();
    public int Length => Tokens.Sum(t => t.Value.Length);
    public bool IsQuestion => Tokens.OfType<Punctuation>().Any(p => p.Symbol == '?');
    public IEnumerable<Word> GetDistinctWordsOfLength(int length) =>
        Words.Where(w => w.HasLength(length))
             .GroupBy(w => w.Value.ToLowerInvariant())
             .Select(g => g.First());
    public override string Value
    {
        get
        {
            var sb = new StringBuilder();
            foreach (var t in Tokens)
            {
                if (sb.Length > 0 && t is not Punctuation) sb.Append(' ');
                sb.Append(t.Value);
            }
            return sb.ToString();
        }
    }
}