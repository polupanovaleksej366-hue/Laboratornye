namespace Lab5.Interfaces;
public interface ISortable<T>
{
    void Sort(IComparer<T> comparer);
    IReadOnlyList<T> Items { get; }
}