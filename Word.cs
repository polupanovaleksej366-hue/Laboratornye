namespace ConcordanceLab.Models;
public class Word : Token
{
    private readonly string _value;
    public override string Value => _value;
    public Word(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Word cannot be empty.");
        _value = value;
    }
}