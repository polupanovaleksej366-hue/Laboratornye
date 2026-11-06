using System.Text;
namespace ConcordanceLab.Models;
public class Sentence : Token
{
    public List<Token> Tokens { get; } = new();
    public IEnumerable<Word> Words => Tokens.OfType<Word>();
    public IEnumerable<Punctuation> Punctuations => Tokens.OfType<Punctuation>();
    public int WordCount => Tokens.OfType<Word>().Count();
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