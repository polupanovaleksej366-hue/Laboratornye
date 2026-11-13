using Lab5.Interfaces;
namespace Lab5.Models;
public abstract class Sweet : ISweet, IComparable<Sweet>
{
    public string Name { get; }
    public double Weight { get; }
    public double Sugar { get; }
    protected Sweet(string name, double weight, double sugar)
    {
        Name = name;
        Weight = weight;
        Sugar = sugar;
    }
    public int CompareTo(Sweet? other) =>
        other is null ? 1 : Sugar.CompareTo(other.Sugar);
    public override string ToString() =>
        $"{Name,-15} weight={Weight,6:F1} g, sugar={Sugar,5:F1} g";
}