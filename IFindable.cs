namespace Lab5.Interfaces;
public interface IFindable<T>
{
    List<T> Find(Predicate<T> predicate);
}