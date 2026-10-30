using System;
using System.Collections.Generic;
using System.Linq;
using TextLab.Models;
using лаба_3_с_.Models;
namespace TextLab.Models;
public class Text : Token
{
    public List<Sentence> Sentences { get; } = new();
    public override string Value => string.Join(" ", Sentences.Select(s => s.Value));
    public IEnumerable<Sentence> OrderByWordCount() => Sentences.OrderBy(s => s.WordCount);
    public IEnumerable<Sentence> OrderByLength() => Sentences.OrderBy(s => s.Length);
    public IEnumerable<Word> FindWordsInQuestions(int length) =>
        Sentences.Where(s => s.IsQuestion)
                  .SelectMany(s => s.GetDistinctWordsOfLength(length))
                  .GroupBy(w => w.Value.ToLowerInvariant())
                  .Select(g => g.First());
    public void RemoveConsonantWordsOfLength(int length)
    {
        foreach (var s in Sentences)
        {
            var toRemove = s.Words.Where(w => w.HasLength(length) && w.StartsWithConsonant()).ToList();
            foreach (var w in toRemove) s.Tokens.Remove(w);
        }
    }
    public void ReplaceInSentence(int sentenceIndex, int length, string replacement)
    {
        if (sentenceIndex < 0 || sentenceIndex >= Sentences.Count)
            throw new ArgumentOutOfRangeException(nameof(sentenceIndex));
        var sentence = Sentences[sentenceIndex];
        var snapshot = sentence.Tokens.ToList();
        sentence.Tokens.Clear();
        foreach (var t in snapshot)
        {
            if (t is Word w && w.HasLength(length))
                sentence.Tokens.Add(new Word(replacement));
            else
                sentence.Tokens.Add(t);
        }
    }
    public void RemoveStopWords(ISet<string> stopWords)
    {
        var set = new HashSet<string>(stopWords, StringComparer.OrdinalIgnoreCase);
        foreach (var s in Sentences)
        {
            var toRemove = s.Words.Where(w => set.Contains(w.Value)).ToList();
            foreach (var w in toRemove) s.Tokens.Remove(w);
        }
    }
}