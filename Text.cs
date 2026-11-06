using System.Collections.Generic;
namespace ConcordanceLab.Models;
public class Text : Token
{
    public List<Sentence> Sentences { get; } = new();
    public override string Value => string.Join(" ", Sentences.Select(s => s.Value));
    public Dictionary<string, WordInfo> BuildConcordance()
    {
        var concordance = new Dictionary<string, WordInfo>(StringComparer.OrdinalIgnoreCase);
        for (int i = 0; i < Sentences.Count; i++)
        {
            int lineNumber = i + 1;
            foreach (var word in Sentences[i].Words)
            {
                string key = word.Value.ToLowerInvariant();
                if (!concordance.TryGetValue(key, out var info))
                {
                    info = new WordInfo();
                    concordance[key] = info;
                }
                info.Frequency++;
                info.LineNumbers.Add(lineNumber); 
            }
        }
        return concordance;
    }
    public SortedDictionary<string, WordInfo> BuildSortedConcordance()
    {
        var dict = BuildConcordance();
        return new SortedDictionary<string, WordInfo>(dict, StringComparer.OrdinalIgnoreCase);
    }
    public void PrintConcordance()
    {
        var concordance = BuildSortedConcordance();
        foreach (var pair in concordance)
        {
            Console.WriteLine(
                $"{pair.Key}. {pair.Value.Frequency}: {string.Join(" ", pair.Value.LineNumbers)}");
        }
    }
}