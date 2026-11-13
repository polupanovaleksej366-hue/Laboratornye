namespace Lab5.Models;
public class Chocolate : Sweet
{
    public int CocoaPercent { get; }
    public Chocolate(string name, double weight, double sugar, int cocoaPercent)
        : base(name, weight, sugar)
    {
        CocoaPercent = cocoaPercent;
    }
    public override string ToString() =>
        base.ToString() + $", cocoa={CocoaPercent}%";
}