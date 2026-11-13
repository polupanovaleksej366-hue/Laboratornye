using Lab5.Interfaces;
using Lab5.Models;
namespace Lab5.Container;
public class Gift : ISortable<Sweet>, IFindable<Sweet>
{
    private readonly List<Sweet> _sweets = new();
    public IReadOnlyList<Sweet> Items => _sweets;
    public void Add(Sweet sweet) => _sweets.Add(sweet);
    public double TotalWeight => _sweets.Sum(s => s.Weight);
    public double TotalSugar => _sweets.Sum(s => s.Sugar);
    public void Sort(IComparer<Sweet> comparer) => _sweets.Sort(comparer);
    public List<Sweet> Find(Predicate<Sweet> predicate) =>
        _sweets.FindAll(predicate);
    public void PrintAll()
    {
        foreach (var s in _sweets)
            Console.WriteLine(s);
    }
}