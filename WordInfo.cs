namespace ConcordanceLab.Models;
public class WordInfo
{
    public int Frequency { get; set; }
    public SortedSet<int> LineNumbers { get; } = new SortedSet<int>();
}