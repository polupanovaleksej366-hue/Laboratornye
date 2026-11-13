namespace Lab5.Models;
public class Candy : Sweet
{
    public string Flavor { get; }
    public Candy(string name, double weight, double sugar, string flavor)
        : base(name, weight, sugar)
    {
        Flavor = flavor;
    }
    public override string ToString() =>
        base.ToString() + $", flavor={Flavor}";
}