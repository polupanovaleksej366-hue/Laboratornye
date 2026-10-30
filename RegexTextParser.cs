using System.Text;
using System.Text.RegularExpressions;
using TextLab.Models;
using лаба_3_с_.Models;
namespace TextLab.Services;
public class RegexTextParser
{
    private static readonly Regex TokenRegex = new Regex(
        @"[\p{L}\p{Nd}]+(?:[-'][\p{L}\p{Nd}]+)*|[.,!?;:()""'«»…—]",
        RegexOptions.Compiled);
    public Text ParseFile(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException($"Файл не найден по пути: {path}");
        return Parse(File.ReadAllText(path, Encoding.UTF8));
    }
    public Text Parse(string content)
    {
        if (content == null) throw new ArgumentNullException(nameof(content));
        var text = new Text();
        var sentence = new Sentence();
        foreach (Match m in TokenRegex.Matches(content))
        {
            string v = m.Value;
            if (v.Length == 1 && ".,!?;:()\"'«»…—".IndexOf(v[0]) >= 0)
            {
                var p = new Punctuation(v[0]);
                sentence.Tokens.Add(p);
                if (p.IsSentenceEnd)
                {
                    if (sentence.WordCount > 0 || sentence.Punctuations.Any())
                        text.Sentences.Add(sentence);
                    sentence = new Sentence();
                }
            }
            else
            {
                sentence.Tokens.Add(new Word(v));
            }
        }
        if (sentence.WordCount > 0 || sentence.Punctuations.Any())
            text.Sentences.Add(sentence);
        return text;
    }
}