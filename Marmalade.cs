namespace Lab5.Models;
public class Marmalade : Sweet
{
    public string Shape { get; }
    public Marmalade(string name, double weight, double sugar, string shape)
        : base(name, weight, sugar)
    {
        Shape = shape;
    }
    public override string ToString() =>
        base.ToString() + $", shape={Shape}";
}